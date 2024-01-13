using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS.classes
{
    public class Device
    {
        public int ID { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
        public string Category { get; set; }    

        public Device(string manufacturer, string model, int price, int count, string category)
        {
            Manufacturer = manufacturer;
            Model = model;
            Price = price;
            Count = count;
            Category = category;
        }

        public Device() { }
    }
}
