using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment26
{
    internal class Program
    {
        static void MapProperties(object source, object destination)
        {
            Type sourceType = source.GetType();
            Type destinationType = destination.GetType();

            PropertyInfo[] sourceProperties = sourceType.GetProperties();
            PropertyInfo[] destinationProperties = destinationType.GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                // Find corresponding property in destination class
                var destinationProperty = Array.Find(destinationProperties, prop => prop.Name == sourceProperty.Name);

                // If the property exists in both classes, map the value
                if (destinationProperty != null && destinationProperty.PropertyType == sourceProperty.PropertyType)
                {
                    var value = sourceProperty.GetValue(source);
                    destinationProperty.SetValue(destination, value);
                }
            }
        }

        static void Main(string[] args)
        {
            // Create instances of Source and Destination classes
            var sourceInstance = new Source { Id = 1, Name = "Product", Price = 10.99 };
            var destinationInstance = new Destination();

            // Call the MapProperties method to map the properties
            MapProperties(sourceInstance, destinationInstance);

            // Display values of properties in the Destination class
            Console.WriteLine($"Destination Id: {destinationInstance.Id}");
            Console.WriteLine($"Destination Name: {destinationInstance.Name}");
            Console.WriteLine($"Destination Price: {destinationInstance.Price}");
            Console.WriteLine($"Destination AdditionalProperty: {destinationInstance.AdditionalProperty}");

            Console.ReadKey();
        }
    }
}
