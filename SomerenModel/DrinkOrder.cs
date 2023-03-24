using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class DrinkOrder
    {
        public int StudentId { get; set; }
        public string DrinkId { get; set; }
        public DateTime DateTime { get{return DateTime.Now; } }
        public int Amount { get { return 1; } }

    }
}
