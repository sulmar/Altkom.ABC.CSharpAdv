using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.ABC.CSharpAdv.ConsoleClient
{
   

    class DynamicTests
    {

        public static void Test()
        {
            DynamicTypeTest();

            ExpandoObjectTest();

            ExpandoObjectDicionaryTest();

            ExpandoObjectJsonTest();


        }

        private static void ExpandoObjectJsonTest()
        {
            string jsonString = "{\"Model\":\"Toyota\",\"Color\":\"Red\",\"ProductionYear\":2017,\"RegistrationDate\":\"2017-12-01T00:00:00\"}";

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter>
                {
                    new MicrosecondEpochConverter()
                }
            };

            dynamic expando = JsonConvert.DeserializeObject<ExpandoObject>(jsonString, settings);
            var expandoProperties = expando as IDictionary<string, dynamic>;

            // Wyświetlenie
            foreach (var property in expandoProperties)
            {
                Console.WriteLine($"{property.Key} - {property.Value} - {property.Value.GetType()}");
            }

            // Install-Package Newtonsoft.Json
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(expando, settings);

            Console.WriteLine(expando.Model);
            Console.WriteLine(expando.Color);

            Console.WriteLine(json);





        }

        private static void ExpandoObjectDicionaryTest()
        {
            //   string jsonString = "{\"Model\":\"Toyota\",\"Color\":\"Red\",\"ProductionYear\":2017}";

            IDictionary<string, dynamic> properties = new Dictionary<string, dynamic>
            {
                { "Model", "Toyota" },
                { "Color", "Red" },
                { "ProductionYear", 2017 },
                { "RegistrationDate", DateTime.Parse("2017-12-01") }
            };

            dynamic expando = new ExpandoObject();
            var expandoProperties = expando as IDictionary<string, dynamic>;

            // Wypełnienie obiektu 
            foreach (var property in properties)
            {
                expandoProperties.Add(property.Key, property.Value);
            }

            // Wyświetlenie
            foreach (var property in expandoProperties)
            {
                Console.WriteLine($"{property.Key} - {property.Value} - {property.Value.GetType()}");
            }

            //Console.WriteLine(expando.Model);
            //Console.WriteLine(expando.Color);
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Converters = new List<JsonConverter>
                {
                    new MicrosecondEpochConverter()
                }

            };
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(expando, settings);
        }

        private static void ExpandoObjectTest()
        {
            dynamic vehicle = new ExpandoObject();

            vehicle.Model = "Mazda";
            vehicle.Color = "Red";
            vehicle.ProductionYear = 2015;

            vehicle.Model = "Toyota";

            var properties = vehicle as IDictionary<string, dynamic>;

            //IDictionary<string, bool> properties = new Dictionary<string, bool>
            //{
            //    { "Model", true },
            //    { "Color", false },
            //    { "ProductionYear", true },

            //};

            foreach (var property in properties)
            {
                Console.WriteLine($"{property.Key} - {property.Value} - {property.Value.GetType()}");
            }

            properties["Model"] = "VW";

            Type type = vehicle.Color.GetType();

            Console.WriteLine(vehicle.Model);
        }

        private static void DynamicTypeTest()
        {
            // DLR 
            dynamic x = 100;

            Console.WriteLine(x);

            x = "Hello";

            Console.WriteLine(x);

        }
    }

    public class MicrosecondEpochConverter : DateTimeConverterBase
    {
        private static readonly DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteRawValue(((DateTime)value - _epoch).TotalMilliseconds + "000");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null) { return null; }
            return _epoch.AddMilliseconds((long)reader.Value / 1000d);
        }
    }
}
