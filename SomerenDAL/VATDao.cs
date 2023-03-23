using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenDAL
{
    public class VATDao : BaseDao
    {
        public List<VATInformation> GetAllVATInformation()
        {
            string query = "SELECT Drink.DrinkId, IsAlcoholic, Price, DateBought, Amount FROM Drink JOIN Buy ON Drink.DrinkId = Buy.DrinkID";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<VATInformation> ReadTables(DataTable dataTable)
        {
            List<VATInformation> VATInformations = new List<VATInformation>();

            foreach (DataRow dr in dataTable.Rows)
            {
                VATInformation VATInformation = new VATInformation()
                {
                    DrinkId = (int)dr["DrinkId"],
                    Price = (double)dr["Price"],
                    SoldAmount = (int)dr["Amount"],
                    DrinkType = (bool)dr["IsAlcoholic"],
                    DrinkBought = (DateTime)dr["DateBought"]

                };
                VATInformations.Add(VATInformation);
            }
            return VATInformations;
        }

    }
}
