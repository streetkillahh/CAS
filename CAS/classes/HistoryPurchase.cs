using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS.classes
{
    public class HistoryPurchase
    {
        public int ID { get; set; }
        public string Date { get; set; } = DateTime.Now.ToString();
        public int Sum { get; set; }
        public int Count { get; set; }
        public string Devices { get; set; }

        public HistoryPurchase() { }
        
    }
}
