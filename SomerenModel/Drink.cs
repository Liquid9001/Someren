using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Drink
    {
        public int Id { get; set; }     // database id
        public string DrinkName { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
    }
}
