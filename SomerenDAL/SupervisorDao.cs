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
    public class SupervisorDao : BaseDao
    {
        public void AssignSupervisor(Teacher teacher, Activities activities)
        {

            string query = "INSERT INTO ActivitySupervisor (lecturerid, activityid) " +
                            "VALUES (@teacherid, @activityid);";
            SqlCommand command = new SqlCommand();
            command.Connection = OpenConnection();
            command.CommandText = query;
            command.Parameters.AddWithValue("@teacherid", teacher.Id);
            command.Parameters.AddWithValue("@activityid", activities.activityId);
            command.ExecuteNonQuery();

        }

        public List<Teacher> GetActivitySupervisors(Activities activities)
        {
            List<Teacher> list = new List<Teacher>();
            string query = "SELECT ActivitySupervisor.lecturerid, lecturer.name  " +
                "FROM ActivitySupervisor " +
                "JOIN lecturer ON ActivitySupervisor.lecturerid = lecturer.lecturerid " +
                "WHERE activityid = @activityid";
            SqlCommand command = new SqlCommand();
            command.Connection = OpenConnection();
            command.CommandText = query;
            command.Parameters.AddWithValue("@activityid", activities.activityId);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Teacher teacher = new Teacher();
                teacher.Id = (int)reader["lecturerid"];
                teacher.FName = (string)reader["name"];
                list.Add(teacher);
            }

            return list;
        }

        public List<Supervisor> GetAllSupervisors()
        {
            string query = "SELECT * " +
                           "from ActivitySupervisor " +
                           "JOIN Lecturer ON ActivitySupervisor.lecturerid = lecturer.lecturerid " +
                           "JOIN activities ON ActivitySupervisor.activityid = activities.id";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        public void DeleteSupervisors(Activities activities)
        {
            string query = "delete from ActivitySupervisor WHERE activityid = @activityid";
            SqlCommand command = new SqlCommand();
            command.Connection = OpenConnection();
            command.CommandText = query;
            command.Parameters.AddWithValue("@activityid", activities.activityId);
            command.ExecuteNonQuery();
        }

        public List<Supervisor> ReadTables(DataTable dataTable)
        {
            List<Supervisor> supervisors = new();

            foreach (DataRow dr in dataTable.Rows)
            {
                Supervisor supervisor = new();

                Teacher teacher = new Teacher();
                teacher.Id = (int)dr["lecturerid"];
                teacher.FName = (string)dr["name"];

                supervisor.teacher = teacher;

                Activities activities = new Activities();
                activities.activityId = (int)dr["activityid"];
                activities.Activity = (string)dr["activity"];

                supervisor.activities = activities;

                supervisors.Add(supervisor);

            }

            return supervisors;
        }
    }
}
