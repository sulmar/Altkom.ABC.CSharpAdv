using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.ABC.CSharpAdv.ConsoleClient
{
    class ReflectionTests
    {

        public static void Test()
        {
            ActivatorTest();

            GetMetadaTest();

            GetCustomAttributesTest();

            SettingTest();
        }

        private static void SettingTest()
        {
            Setting setting = new Setting();

            setting.Set("Option3", 100);

            setting["Option1"] = true;

            Console.WriteLine(setting["Option1"]);
        }

        private static void ActivatorTest()
        {
            string classname = "Customer";

            string objectToInstance = $"Altkom.ABC.CSharpAdv.ConsoleClient.{classname}, Altkom.ABC.CSharpAdv.ConsoleClient";

            Type objectType = Type.GetType(objectToInstance);

            if (objectType == null)
            {
                throw new NotSupportedException(classname);
            }

            var instance = Activator.CreateInstance(objectType);

            objectType.GetProperty("Id").SetValue(instance, 999);

            object value = objectType.GetProperty("Id").GetValue(instance);


        }

        private static void GetCustomAttributesTest()
        {
            Type type = typeof(Customer);

            IEnumerable<Attribute> attributes = System.Attribute.GetCustomAttributes(type);

            foreach (Attribute attribute in attributes)
            {
                if (attribute is Author)
                {
                    Author author = attribute as Author;

                    Console.WriteLine($"Author {author.Name}");
                }
            }


           

        }

        private static void GetMetadaTest()
        {
            Type type = typeof(Customer);

            PropertyInfo[] properties  = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine($"{property.Name} {property.PropertyType.Name}");

                var attributes = property.GetCustomAttributes();

                foreach (Attribute attribute in attributes)
                {
                    if (attribute is Visibility)
                    {
                        Visibility visibility = attribute as Visibility;

                        Console.WriteLine($"Visible {visibility.IsVisible}");
                    }
                }

            }
        }


    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class Author : Attribute
    {
        public string Name { get; private set; }

        public Author(string name)
        {
            this.Name = name;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class Visibility : Attribute
    {
        private bool isVisible;

        public bool IsVisible => isVisible;

        public Visibility(bool isVisible)
        {
            this.isVisible = isVisible;
        }
    }


    public static class PropertyExtension
    {
        public static void Set(this object _object, string propertyName, object value)
        {
            _object.GetType().GetProperty(propertyName).SetValue(_object, value, null);
        }

        public static object Get(this object _object, string propertyName)
        {
            return _object.GetType().GetProperty(propertyName).GetValue(_object);
        }
    }
}
