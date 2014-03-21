using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace CMSExpress.AppServices.Mvc
{
    public static class JsonSerialize
    {
        public static T Clone<T>(this T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("In order to clone, the incoming type '{0}' must be serializable" + (typeof(T).FullName), "source");
            }

            if (ReferenceEquals(source, null))
            {
                return default(T);
            }

            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }

        public static T Deserialize<T>(string json)
        {
            var value = Deserialize(json, typeof(T));
            return (value == null ? default(T) : (T)value);
        }

        public static object Deserialize(string json, Type objectType)
        {
            if (string.IsNullOrEmpty(json) || json.Length <= 3)
                return null;
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            serializer.Deserialize(new StringReader(json), objectType);
            return null;
        }

        public static string Serialize(object value, bool propertyNameCamelCase = false)
        {
            var type = value.GetType();
            if (type.IsPrimitive || typeof(string).IsAssignableFrom(type))
                return value.ToString();

            var dateTimeStyle = "yyyy-MM-dd HH:mm:ss";
            if (typeof(DateTime).IsAssignableFrom(type) || typeof(DateTimeOffset).IsAssignableFrom(type))
                return Convert.ToDateTime(value).ToString(dateTimeStyle);

            var serializer = new Newtonsoft.Json.JsonSerializer();
            if (propertyNameCamelCase)
                serializer.ContractResolver = new CamelCasePropertyNamesContractResolver();

            var dateTimeConverter = new IsoDateTimeConverter
            {
                DateTimeStyles = System.Globalization.DateTimeStyles.None,
                DateTimeFormat = dateTimeStyle
            };

            if (typeof(IDictionary).IsAssignableFrom(type))
                return JObject.FromObject(value, serializer).ToString(Formatting.None, dateTimeConverter);

            if (type.IsArray || (typeof(IEnumerable).IsAssignableFrom(type)))
                return JArray.FromObject(value, serializer).ToString(Formatting.None, dateTimeConverter);

            return JObject.FromObject(value, serializer).ToString(Formatting.None, dateTimeConverter);
        }
    }
}
