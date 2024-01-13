using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAS.classes
{
    public class VideoCard
    {
        public string Manufacture { get; set; } // производитель
        public string Series { get; set; }
        public string Model { get; set; }

        public VideoCard(string Manufacture, string Series, string Model)
        {
            this.Manufacture = Manufacture;
            this.Series = Series;
            this.Model = Model;
        }
    }
}
