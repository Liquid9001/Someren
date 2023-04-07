using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenModel;
using System.Configuration;

namespace SomerenDAL
{
    public class ParticipantsDao : BaseDao
    {
       
        public List<Participants> GetAllParticipants()
        {
            string query = "SELECT ActivityId,Name FROM [Activity]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Participants> ReadTables(DataTable dataTable)
        {
            List<Participants> participants = new();

            foreach (DataRow dr in dataTable.Rows)
            {
                Participants participant = new()
                {
                    ActivityId = (int)dr["ActivityId"],
                    Activity = dr["Name"].ToString(),
                 

                };
                participants.Add(participant);
            }
            return participants;
        }
    }
}
