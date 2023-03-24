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
        //this method collects drinks for drinkorder signed by Enes
        public List<Drink> CollectAllDrinks()
        {
            string query = "SELECT DrinkId, Drinkname, Stock, Price FROM [Drink] WHERE Stock > 1";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }
        //reads drinks
        private List<Drink> ReadTables(DataTable dataTable)
        {
            List<Drink> drinks = new List<Drink>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Drink drink = new Drink()
                {
                    Id = (int)dr["DrinkId"],
                    DrinkName = dr["DrinkName"].ToString(),
                    Stock = (int)dr["Stock"],
                    Price = (double)dr["Price"]
                };

                drinks.Add(drink);
            }
            return drinks;
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
