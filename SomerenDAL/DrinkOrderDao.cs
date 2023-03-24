using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenDAL
{
    public class DrinkOrderDao : BaseDao
    {
        public void AddOrder(DrinkOrder drinkOrder)
        {
            string querry = "INSERT INTO Buy (DrinkId, StudentId, DateBought, Amount)" +
                                "VALUES (@DrinkId, @StudentId, @DateBought, @Amount)";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@DrinkId",drinkOrder.DrinkId),
                new SqlParameter("@StudentId",drinkOrder.StudentId),
                new SqlParameter("@DateBought",drinkOrder.DateTime),
                new SqlParameter("@Amount", drinkOrder.Amount)

            };
            OpenConnection();
            ExecuteEditQuery(querry, sqlParameters);

        }

        public void UpdateStock(DrinkOrder drinkOrder)
        {
            string querry = "UPDATE Drink SET Stock = Stock - @Amount " +
                                "WHERE DrinkId = @DrinkId";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@DrinkId",drinkOrder.DrinkId),
                new SqlParameter("@Amount", drinkOrder.Amount)
            };
            OpenConnection();
            ExecuteEditQuery(querry, sqlParameters);
        }

    }
}
