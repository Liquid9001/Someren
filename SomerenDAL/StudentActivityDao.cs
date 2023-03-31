using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenModel;

namespace SomerenDAL
{
    public class StudentActivityDao : BaseDao
    {
        public List<ActivityStudent> GetAllStudentsActivity()
        {
            string query = "SELECT activity.name, student.firstname, student.lastname FROM [ActivityStudent]" +
                                       "JOIN Student ON ActivityStudent.Studentid = Student.Studentid" +
                                       "JOIN Activity ON ActivityStudent.activityid = activity.activityid";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<ActivityStudent> ReadTables(DataTable dataTable)
        {
            List<ActivityStudent> activityStudents = new();

            foreach (DataRow dr in dataTable.Rows)
            {
                ActivityStudent activityStudent = new()
                {
                   
                    ActivityName = dr["Name"].ToString(),
                    FirstName = dr["FirstName"].ToString(),
                    LastName = dr["LastName"].ToString()
                };
                activityStudents.Add(activityStudent);
            }
            return activityStudents;
        }
    }
}
