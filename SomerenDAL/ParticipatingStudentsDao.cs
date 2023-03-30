using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenModel;

namespace SomerenDAL
{
    public class ParticipatingStudentsDao : BaseDao
    {
        private SqlConnection dbConnection;

        public ParticipatingStudentsDao()
        {
            string connString = ConfigurationManager
            .ConnectionStrings["SomerenDatabase"]
           .ConnectionString;
            dbConnection = new SqlConnection(connString);
        }
        public List<StudentParticipating> GetAllParticipatingStudents()
        {
            string query = "SELECT StudentId, FirstName, LastName FROM [Student]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<StudentParticipating> ReadTables(DataTable dataTable)
        {
            List<StudentParticipating> studentsParticipating = new();

            foreach (DataRow dr in dataTable.Rows)
            {
                StudentParticipating participating = new()
                {
                    StudentId = (int)dr["StudentId"],
                    FirstName = dr["FirstName"].ToString(),
                    LastName = dr["LastName"].ToString(),


                };
                studentsParticipating.Add(participating);
            }
            return studentsParticipating;
        }
    }
}
