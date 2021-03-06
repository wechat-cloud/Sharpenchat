﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Sharpenchat.Core;
using Sharpenchat.Core.Serialization;

namespace Sharpenchat
{
    internal class DefaultSignatureService : ISignatureService
    {
        private readonly IDigestHmacSha256 _digestHmacSha256;
        private readonly IDigestMd5 _digestMd5;

        public DefaultSignatureService(IDigestMd5 digestMd5, IDigestHmacSha256 digestHmacSha256) {
            _digestMd5 = digestMd5;
            _digestHmacSha256 = digestHmacSha256;
        }

        public void GenSign<T>(string key, T obj, Action<string> onSign) {
            GenSign(key, obj, SignatureType.Md5, onSign);
        }

        public void GenSign<T>(string key, T obj, SignatureType signatureType, Action<string> onSign) {
            if (string.IsNullOrEmpty(key)) {
                throw new ArgumentException("key is required", nameof(key));
            }
            if (obj == null) {
                throw new ArgumentNullException(nameof(obj));
            }

            if (onSign == null) {
                return;
            }

            var dict = new SortedDictionary<string, string>();

            var type = obj.GetType();
            var properties = type.GetRuntimeProperties();

            foreach (var property in properties) {
                if (property.GetCustomAttribute<IgnoreAttribute>() != null) {
                    continue;
                }

                var fieldValue = property.GetValue(obj)?.ToString();
                if (string.IsNullOrEmpty(fieldValue)) {
                    continue;
                }

                var fieldName = property.Name;
                var fieldNameAttr = property.GetCustomAttribute<FieldNameAttribute>();
                if (fieldNameAttr != null) {
                    fieldName = fieldNameAttr.Name;
                }

                dict.Add(fieldName, fieldValue);
            }

            var raw = string.Join("&", dict.Select(kv => $"{kv.Key}={kv.Value}")) + $"&key={key}";

            var sign = ComputeSignature(signatureType, raw);
            onSign(sign);
        }

        public ISignatureService GenNonce(Action<string> onNonce) {
            if (onNonce != null) {
                var nonce = Guid.NewGuid().ToString("n");
                onNonce(nonce);
            }

            return this;
        }

        private string ComputeSignature(SignatureType signatureType, string raw) {
            if (signatureType == SignatureType.Md5) {
                return _digestMd5.Process(raw);
            }
            if (signatureType == SignatureType.HmacSha256) {
                return _digestHmacSha256.Process(raw);
            }

            throw new Exception("unknown signature type");
        }
    }
}