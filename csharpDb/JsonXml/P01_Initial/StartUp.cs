using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using P01_Initial.Data.Models;
using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace P01_Initial
{
    public class StartUp
    {
        // Verbatim String --> @""

        public static void Main()
        {
            //var jsonString = One();  //JSON (JavaScript Object Notation) //Сериализация
            //var product = Two<Product>(jsonString); //Десериализация
            //var jsonString2 = Three(); // NewtonSoft Json.Net ще ползваме (JSON.NET е library-то) 
            //         // install-package Newtonsoft.Json
            //Four<Product>(jsonString2); //Deserialize using Newtonsoft.Json

            //var outputJson = Five(); //Serialize Anonymus type
            //Six(outputJson); //Deserialize Anonymus type
            //Seven();
            //Eight();
            Nine();
        }

        private static void Nine()
        {
            var json = JObject.Parse(@"{'products': [{'name': 'Fruits', 'products': ['apple', 'banana']},{'name': 'Vegetables', 'products': ['cucumber']}]}");

            var productsArray = json["products"]
                    .Select(t => $"{t["name"]} - {string.Join(", ", t["products"])}")
                    .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, productsArray));
        }

        private static void Eight()
        {
            JObject json = JObject.Parse("{'Name':'Pesho', 'Age': 15, 'RandomElements': [ 2.5, 'Gosho']}");

            //JToken 1 стойност от JSON-a
            foreach (var kvp in json)
            {
                var key = kvp.Key;
                var value = kvp.Value;/*.ToObject<string>();*/ // <-- Това го пишем, за да строго типизираме JSON-a (по-добре е да ги парсваме към някакви обекти и да си правим някакви Data transfer Obejcts (DTO-та) с тях)

                Console.WriteLine($"{key}: {value}");
            }
        }

        private static void Seven()
        {
            var product = new Product()
            {
                Name = "Tire",
                Description = "Makes the car go",
                Manufacturer = new Manufacturer()
                {
                    Name = "Michelin"
                }
            };

            var json = JObject.FromObject(product);

            //json.ToString();

            Console.WriteLine();
        }

        private static void Six(string outputJson)
        {
            var template = new
            {
                Name = default(string),
                Age = default(int),
                Grades = new decimal[] { }
            };

            var deserializeObj = JsonConvert.DeserializeAnonymousType(outputJson, template);
        }

        private static string Five()
        {
            var obj = new
            {
                Name = "Pesho",
                Age = 21,
                Grades = new[]
                {
                    5.50,
                    2.20,
                    4.20,
                    69
                }
            };

            var outputJson = JsonConvert.SerializeObject(obj, Formatting.Indented);

            Console.WriteLine(outputJson);

            return outputJson;
        }

        private static void Four<T>(string jsonString)
        {
            var parsedProduct = JsonConvert.DeserializeObject<T>(jsonString);
        }

        private static string Three()
        {
            var product = new Product()
            {
                Name = "Tire",
                Description = "Makes the car go"
            };

            var jsonString = JsonConvert.SerializeObject(product,Formatting.Indented, new JsonSerializerSettings()
            {
                //NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore
            });

            Console.WriteLine(jsonString);
            return jsonString;
        }

        private static T Two<T>(string jsonString)
        {
            var product = DeserializeJason<T>(jsonString);
            return product;
        }

        private static T DeserializeJason<T>(string jsonString)
        {
            var serializer = new DataContractJsonSerializer(typeof(T));
            var jsonStringBytes = Encoding.UTF8.GetBytes(jsonString);
            using (var stream = new MemoryStream(jsonStringBytes))
            {
                var result = (T)serializer.ReadObject(stream);
                return result;
            }

        }

        private static string One()
        {
            var product = new Product()
            {
                Name = "Tire",
                Description = "Makes the car go"
            };

            var jsonString = SerializableObject(product);
            Console.WriteLine(jsonString);

            return jsonString;
        }

        private static string SerializableObject<T>(T obj)
        {
            var jsonSerializer = new DataContractJsonSerializer(obj.GetType());

            using (var stream = new MemoryStream())
            {
                jsonSerializer.WriteObject(stream, obj);
                var result = Encoding.UTF8.GetString(stream.ToArray());

                return result;
            }

        }
    }
}
