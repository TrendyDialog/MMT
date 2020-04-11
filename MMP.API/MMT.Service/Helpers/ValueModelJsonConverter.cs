using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace MMT.Service.Helpers
{
    public class ValueModelJsonConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType)
        {
            return typeof(ValueModel).IsAssignableFrom(objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException("Custom converter should only be used while deserializing.");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            // Load JObject from stream
            JObject jObject = JObject.Load(reader);
            if (jObject == null)
                return null;

            ValueType valueType;
            if (Enum.TryParse(jObject.Value<string>("type"), true, out valueType))
            {
                switch (valueType)
                {
                    case ValueType.String:
                        var stringValueModel = new StringValueModel();
                        serializer.Populate(jObject.CreateReader(), stringValueModel);
                        return stringValueModel;
                    case ValueType.Integer:
                        var intValueModel = new IntValueModel();
                        serializer.Populate(jObject.CreateReader(), intValueModel);
                        return intValueModel;
                    case ValueType.BigInt:
                        var bigIntValueModel = new IntValueModel();
                        serializer.Populate(jObject.CreateReader(), bigIntValueModel);
                        return bigIntValueModel;
                    default:
                        throw new ArgumentException($"Unknown value type '{valueType}'");
                }
            }

            throw new ArgumentException($"Unable to parse value object");
        }
    }

    public enum ValueType
    {
        String,
        Integer,
        BigInt
    }

    public abstract class ValueModel
    {
        public abstract ValueType Type { get; }

        [JsonProperty]
        public long Id { get; set; }
        [JsonProperty]
        public string CellName { get; set; }
        [JsonProperty]
        public string RowName { get; set; }
        public string Column1 { get; set; }
        public string Column2 { get; set; }
        public string Column3 { get; set; }
        public string Column4 { get; set; }
        public string Column5 { get; set; }
        public string Column6 { get; set; }
        public string Column7 { get; set; }
        public string Column8 { get; set; }
        public string Column9 { get; set; }
        public string Column10 { get; set; }
        public string Column11 { get; set; }
        public string Column12 { get; set; }
        public string Column13 { get; set; }
        public string Column14 { get; set; }
        public string Column15 { get; set; }
        public string Column16 { get; set; }
        public string Column17 { get; set; }
        public string Column18 { get; set; }
        public string Column19 { get; set; }
        public string Column20 { get; set; }
        public string Column21 { get; set; }
        public string Column22 { get; set; }
        public string Column23 { get; set; }
        public string Column24 { get; set; }
        public string Column25 { get; set; }
        public string Column26 { get; set; }
        public string Column27 { get; set; }
        public string Column28 { get; set; }
        public string Column29 { get; set; }
        public string Column30 { get; set; }
    }

    public class StringValueModel : ValueModel
    {
        [JsonProperty]
        public string Value { get; set; }

        public override ValueType Type => ValueType.String;
    }

    public class IntValueModel : ValueModel
    {
        [JsonProperty]
        public int Value { get; set; }

        public override ValueType Type => ValueType.Integer;
    }
    
    public class BigIntValueModel : ValueModel
    {
        [JsonProperty]
        public long Value { get; set; }

        public override ValueType Type => ValueType.BigInt;
    }
}
