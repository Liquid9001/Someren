﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenDAL;
using SomerenModel;

namespace SomerenService
{
    public class DrinksService
    {
        private DrinksDao drinksdb;
        public DrinksService()
        {
            drinksdb = new DrinksDao();
        }

        public List<Drink> GetDrinks()
        {
            List<Drink> drinks = drinksdb.GetAllDrinks();
            return drinks;
        }

        public List<Drink> CollectDrinks()
        {
            List<Drink> drinks = drinksdb.CollectAllDrinks();
            return drinks;
        }

        public void UpdateDrink(Drink drink)
        {
            drinksdb.UpdateDrink(drink);
        }

    }
}
