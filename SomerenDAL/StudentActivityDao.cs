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
            string query = "SELECT ActivityStudent.ActivityId ,ActivityStudent.StudentId, Activity.Name, Student.FirstName, Student.LastName FROM [ActivityStudent] " +
                                       "JOIN [Student] ON ActivityStudent.StudentId = Student.StudentId " +
                                       "JOIN [Activity] ON ActivityStudent.ActivityId = Activity.ActivityId ORDER BY Student.LastName";
                                      
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
                    StudentId = (int)dr["StudentId"],
                    ActivityId = (int)dr["ActivityId"],
                    ActivityName = dr["Name"].ToString(),
                    FirstName = dr["FirstName"].ToString(),
                    LastName = dr["LastName"].ToString()
                };
                activityStudents.Add(activityStudent);
            }
            return activityStudents;
        }
        public void RemoveStudentActivity(ActivityStudent student)
        {
            string query = "DELETE FROM [ActivityStudent] WHERE StudentId = @StudentId AND ActivityId = @ActivityId ";
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@StudentId", student.StudentId),
                new SqlParameter("ActivityId", student.ActivityId)
            };
            OpenConnection();
            ExecuteEditQuery(query, sqlParameters);
        }
        public void AddStudentActivity(Student student, Activities activities)
        {
            string query = "INSERT INTO [ActivityStudent] (StudentId, ActivityId) " +
                            "VALUES (@StudentId, @ActivityId);";

            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@StudentId", student.Id),
                new SqlParameter("@ActivityId", activities.activityId)
            };
            OpenConnection();
            ExecuteEditQuery(query, sqlParameters);
        }
    }
}
