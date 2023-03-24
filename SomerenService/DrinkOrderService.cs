using SomerenModel;
using SomerenDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SomerenService
{
    public class DrinkOrderService
    {
        DrinkOrderDao drinkOrderDao = new DrinkOrderDao();
        

        public void AddOrder(DrinkOrder drinkOrder)
        {

            drinkOrderDao.AddOrder(drinkOrder);

        }
        //collects drinks
        public List<Drink> CollectDrinks()
        {
            List<Drink> drinks = drinkOrderDao.CollectAllDrinks();
            return drinks;
        }


        public void UpdateStock(DrinkOrder drinkOrder)
        {
            drinkOrderDao.UpdateStock(drinkOrder);
        }
    }
}
