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
    public class ListOfActivitiesDao : BaseDao
    {
        public List<Activities> GetAllActivities()
        {
            string query = "SELECT ActivityId, [Name], StartTimeActivity, EndTimeActivity FROM [Activity]";
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

        public void AddActivity(Activities activities)
        {
            string querry = "INSERT INTO Activity (ActivityId, [Name], StartTimeActivity, EndTimeActivity)" +
                                "VALUES (@ActivityId, @Name, @StartTimeActivity, @EndTimeActivity)";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@ActivityId",activities.activityId),
                new SqlParameter("@Name",activities.Activity),
                new SqlParameter("@StartTimeActivity",activities.dateTime),
                new SqlParameter("@EndTimeActivity", activities.EndDateTime)

            };
            OpenConnection();
            ExecuteEditQuery(querry, sqlParameters);

        }

        public void DeleteActivity(Activities activities)
        {
            string querry = "DELETE FROM Activity WHERE ActivityId = @ActivityId";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@ActivityId",activities.activityId),
            };
            OpenConnection();
            ExecuteEditQuery(querry, sqlParameters);
        }

        public void UpdateActivity(Activities activities)
        {
            string querry = "UPDATE Activity SET (ActivityId=@ActivityId, [Name]=@Name, StartTimeActivity=@StartTimeActivity, EndTimeActivity=@EndTimeActivity)";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@ActivityId",activities.activityId),
                new SqlParameter("@Name",activities.Activity),
                new SqlParameter("@StartTimeActivity",activities.dateTime),
                new SqlParameter("@EndTimeActivity", activities.EndDateTime)

            };
            OpenConnection();
            ExecuteEditQuery(querry, sqlParameters);

        }

    }
}
