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
    public class ActivitiesDao : BaseDao
    {
        public List<Activities> GetAllActivities()
        {
            string query = "SELECT ActivityId, Name, StartTimeActivity FROM [Activity]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Activities> ReadTables(DataTable dataTable)
        {
            List<Activities> activities = new();

            foreach (DataRow dr in dataTable.Rows)
            {
                Activities activity = new()
                {
                    activityId = (int)dr["ActivityId"],
                    Activity = dr["Name"].ToString(),
                    dateTime = (DateTime)dr["StartTimeActivity"]
                };
                activities.Add(activity);
            }
            return activities;
        }
    }
}
