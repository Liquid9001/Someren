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
    public class WeeklyTimetableDao : BaseDao
    {
        public List<WeeklyTimetable> GetActivitiesWeeklyTimetable()
        {
            string query = "SELECT Activity.ActivityId, Activity.[Name], Activity.StartTimeActivity, Supervise.TeacherId From Activity LEFT OUTER JOIN Supervise ON Activity.ActivityId = Supervise.ActivityId";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTableActivities(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<WeeklyTimetable> ReadTableActivities(DataTable dataTable)
        {
            List<WeeklyTimetable> weeklyTimetables = new List<WeeklyTimetable>();

            foreach (DataRow dr in dataTable.Rows)
            {
                WeeklyTimetable weeklyTimetable = new WeeklyTimetable()
                {
                    ActivityId = (int)dr["ActivityId"],
                    DateOfActivity = (DateTime)dr["StartTimeActivity"],
                    Activity = (string)dr["Name"],
                    TeacherId = 0// (int)dr["TeacherId"]==null,

                };
                weeklyTimetables.Add(weeklyTimetable);
            }
            return weeklyTimetables;
        }

        
    }
}
