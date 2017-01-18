using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Sharpenchat.Core.Serialization;

namespace Sharpenchat
{
    public class Wechat
    {
        internal static T GetService<T>() {
            if (typeof(T) == typeof(IJsonSerializer)) {
                object s = new DefaultJsonSerializer();
                return (T)s;
            }
            throw new NotImplementedException();
        }

        public static T LoadConfiguration<T>(Assembly assembly, string resource) {
            using (var stream = assembly.GetManifestResourceStream(resource)) {
                using (var reader = new StreamReader(stream, Encoding.UTF8)) {
                    var jsonSerializer = GetService<IJsonSerializer>();
                    return jsonSerializer
                        .DeserializeAsync<T>(reader)
                        .ConfigureAwait(false)
                        .GetAwaiter()
                        .GetResult();
                }
            }
        }
    }
}
