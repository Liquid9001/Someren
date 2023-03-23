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
    public class RevenueDao : BaseDao
    {
        public List<Revenue> GetDateRangeSales(DateTime startDate, DateTime endDate)
        {
            string query = "SELECT COALESCE(COUNT(DISTINCT student.studentid), 0) AS number_of_customers, " +
                            "COALESCE(SUM(amount * price), 0) AS turnover, COALESCE(SUM(amount), 0) AS sales " +
                            "FROM buy " +
                            "JOIN student ON buy.studentid = student.studentid " +
                            "JOIN drink ON buy.drinkid = drink.drinkid " +
                            "WHERE datebought between @startDate AND @endDate";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQueryWithValues(query, "@startDate", startDate, "@endDate", endDate, sqlParameters));
        }

        private List<Revenue> ReadTables(DataTable dataTable)
        {
            List<Revenue> revenues = new List<Revenue>();
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (DataRow dr in dataTable.Rows)
                {
                    Revenue revenue = new()
                    {
                        numberOfCustomer = (int)dr["number_of_customers"],
                        turnOver = (double)dr["turnover"],
                        sales = (int)dr["Sales"]
                    };
                    revenues.Add(revenue);
                }
            }
            else
            {

            }
            return revenues;
        }
    }
}
