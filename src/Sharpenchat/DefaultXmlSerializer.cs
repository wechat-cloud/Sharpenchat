using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Sharpenchat.Core.Serialization;

namespace Sharpenchat
{
    public class DefaultXmlSerializer : IXmlSerializer
    {
        private static readonly Type[] _simpleTypes = {
            typeof(ushort), typeof(uint), typeof(ulong),
            typeof(short), typeof(int), typeof(long),
            typeof(string)
        };

        public async Task SerializeAsync<T>(T target, TextWriter writer) {
            var sb = new StringBuilder();

            sb.AppendLine(@"<xml>");
            ParseEntity(target, sb);
            sb.AppendLine(@"</xml>");

            var xml = sb.ToString();
            await writer.WriteAsync(xml);
        }

        public async Task<T> DeserializeAsync<T>(TextReader reader) {
            throw new NotImplementedException();
        }

        private void ParseEntity(object target, StringBuilder builder) {
            var objType = target.GetType();
            var properties = objType
                .GetRuntimeProperties()
                .Where(p => p.GetCustomAttribute<IgnoreAttribute>() == null)
                .Select(p => new {
                    PropertyName = GetPropertyName(p),
                    PropertyValue = GetPropertyValue(p, target),
                    p.PropertyType
                })
                .Where(p => !string.IsNullOrEmpty(p.PropertyValue))
                .OrderBy(p => p.PropertyName);

            foreach (var p in properties) {
                if (p.PropertyValue == null) {
                    continue;
                }

                if (_simpleTypes.Contains(p.PropertyType)) {
                    builder.AppendLine($"<{p.PropertyName}>{p.PropertyValue}</{p.PropertyName}>");
                } else {
                    ParseEntity(p.PropertyValue, builder);
                }
            }
        }

        private string GetPropertyName(PropertyInfo propertyInfo) {
            var fieldAttr = propertyInfo.GetCustomAttribute<FieldNameAttribute>();
            var propertyName = propertyInfo.Name;
            if (fieldAttr != null) {
                propertyName = fieldAttr.Name;
            }

            return propertyName;
        }

        private string GetPropertyValue(PropertyInfo propertyInfo, object obj) {
            var v = propertyInfo.GetValue(obj);
            var display = v?.ToString();

            if (string.IsNullOrEmpty(display)) {
                return string.Empty;
            }

            //if (propertyInfo.GetCustomAttribute<ProtectAttribute>() != null) {
            //    display = $"<![CDATA[{display}]]>";
            //}

            if (propertyInfo.PropertyType == typeof(string)) {
                display = $"<![CDATA[{display}]]>";
            }

            return display;
        }
    }
}