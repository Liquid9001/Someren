using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class VATInformation
    {
        public int DrinkId { get; set; }         // database id
        public double Price { get; set; }     // price of drink
        public int SoldAmount { get; set; }   // number of drinks sold
        public bool DrinkType { get; set; }      // non-alcoholic = false, alcoholic = true

        public DateTime DrinkBought { get; set; }   // date of drink that was ordered

    }
}
