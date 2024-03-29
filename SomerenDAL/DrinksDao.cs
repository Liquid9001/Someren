﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenModel;


namespace SomerenDAL
{
    public class DrinksDao : BaseDao
    {
       
        public List<Drink> GetAllDrinks()
        {
            string query = "SELECT DrinkId, Drinkname, Stock, Price, Token FROM [Drink] WHERE Stock > 1 AND Token > 1 ORDER BY Stock";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        //this method collects drinks for drinkorder signed by Enes
        public List<Drink> CollectAllDrinks()
        {
            string query = "SELECT DrinkId, Drinkname, Stock, Price FROM [Drink] WHERE Stock > 1";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Drink> ReadTables(DataTable dataTable)
        {
            List<Drink> drinks = new List<Drink>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Drink drink = new Drink(

                    (int)dr["DrinkId"],
                   dr["DrinkName"].ToString(),
                    (int)dr["Stock"],
                   (double)dr["Price"],
                   (int)dr["Token"]
                );
                drinks.Add(drink);
            }
            return drinks;
        }
        public void UpdateDrink(Drink drink)
        {
            string query = "UPDATE Drink SET DrinkName=@DrinkName, Stock=@Stock WHERE DrinkId=@DrinkId";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@DrinkName", drink.DrinkName),
                new SqlParameter("@Stock", drink.Stock),
                new SqlParameter("@DrinkId", drink.Id)
            };
            OpenConnection();
            ExecuteEditQuery(query, sqlParameters);
        }
    }
}
