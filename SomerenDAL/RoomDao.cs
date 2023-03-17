using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;

namespace SomerenDAL
{
    public class RoomDao : BaseDao
    {
        public List<Room> GetAllRooms()
        {
            string query = "SELECT RoomId, RoomNumber, RoomCapacity, Type FROM [Room]";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Room> ReadTables(DataTable dataTable)
        {
            List<Room> rooms = new List<Room>();

            foreach(DataRow dr in dataTable.Rows)
            {
                Room room = new Room()
                {
                    Id = (int)dr["RoomId"],
                    Number = (int)dr["RoomNumber"],
                    Capacity = (int)dr["RoomCapacity"],
                    Type = (bool)dr["Type"]
                };
                rooms.Add(room);
            }
            return rooms;
        }
    }
}

