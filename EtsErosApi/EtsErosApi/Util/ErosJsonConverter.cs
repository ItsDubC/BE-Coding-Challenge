using EtsErosApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace EtsErosApi.Util
{
    public class ErosJsonConverter : JsonConverter
    {
        private readonly Type[] _types;

        public ErosJsonConverter(params Type[] types)
        {
            _types = types;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            TreeNode node = (TreeNode)value;

            // Build inner
            JObject innerObj = new JObject();
            innerObj.Add("label", node.Label);
            innerObj.Add("children", JArray.FromObject(node.Children, serializer));

            // Add to outer w/ ID
            JObject obj = new JObject();
            obj.Add(node.Id.ToString(), innerObj);

            // Add to array & write
            JArray arr = new JArray();
            arr.Add(obj);

            arr.WriteTo(writer);
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
