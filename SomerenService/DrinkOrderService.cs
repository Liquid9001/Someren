using SomerenModel;
using SomerenDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenService
{
    public class DrinkOrderService
    {
        DrinkOrderDao drinkOrderDao = new DrinkOrderDao();

        public void AddOrder(DrinkOrder drinkOrder)
        {

            drinkOrderDao.AddOrder(drinkOrder);

        }

        public void UpdateStock(DrinkOrder drinkOrder)
        {
            drinkOrderDao.UpdateStock(drinkOrder);
        }
    }
}
