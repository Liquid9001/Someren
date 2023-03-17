using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using SomerenModel;

namespace SomerenDAL
{
    public class TeacherDao : BaseDao
    {
        public List<Teacher> GetAllTeachers()
        {
            string query = "SELECT TeacherId, FirstName, LastName, LecturerNumber FROM [Teacher]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Teacher> ReadTables(DataTable dataTable)
        {
            List<Teacher> teachers = new List<Teacher>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Teacher teacher = new Teacher()
                {
                    Id = (int)dr["TeacherId"],
                    FName = dr["FirstName"].ToString(),
                    LName = dr["LastName"].ToString(),
                    Number = (int)dr["LecturerNumber"]
                };
                teachers.Add(teacher);
            }
            return teachers;
        }
    }
}
