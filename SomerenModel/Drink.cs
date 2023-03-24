﻿using System;
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
        public double Price { get; set; }
        public int Token {get; set; }

        public Drink()
        { }
        public Drink(int id, string drinkName, int stock, double price, int token)
        {
            Id = id;
            DrinkName = drinkName;
            Stock = stock;
            Price = price;
            Token = token;
        }
    }
}
