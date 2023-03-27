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

            string query = "INSERT INTO Supervise (teacherid, activityid) " +
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
            string query = "SELECT Supervise.teacherid, teacher.firstname  " +
                "FROM Supervise " +
                "JOIN teacher ON Supervise.teacherid = teacher.teacherid " +
                "WHERE activityid = @activityid";
            SqlCommand command = new SqlCommand();
            command.Connection = OpenConnection();
            command.CommandText = query;
            command.Parameters.AddWithValue("@activityid", activities.activityId);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Teacher teacher = new Teacher();
                teacher.Id = (int)reader["teacherid"];
                teacher.FName = (string)reader["firstname"];
                list.Add(teacher);
            }

            return list;
        }

        public List<Supervisor> GetAllSupervisors()
        {
            string query = "SELECT * " +
                           "from Supervise " +
                           "JOIN teacher ON Supervise.teacherid = teacher.teacherid " +
                           "JOIN activity ON Supervise.activityid = activity.activityid";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        public void DeleteSupervisors(Activities activities)
        {
            string query = "delete from Supervise WHERE activityid = @activityid";
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
                teacher.Id = (int)dr["teacherid"];
                teacher.FName = (string)dr["firstname"];

                supervisor.teacher = teacher;

                Activities activities = new Activities();
                activities.activityId = (int)dr["activityid"];
                activities.Activity = (string)dr["Name"];

                supervisor.activities = activities;

                supervisors.Add(supervisor);

            }

            return supervisors;
        }
    }
}
