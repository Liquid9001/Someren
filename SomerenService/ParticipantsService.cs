using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenDAL;
using SomerenModel;

namespace SomerenService
{
    public class ParticipantsService
    {
        private ParticipantsDao participantsdb;

        public ParticipantsService()
        {
            participantsdb = new();
        }

        public List<Participants> GetParticipants()
        {
            List<Participants> participants = participantsdb.GetAllParticipants();
            return participants;
        }
    }
}
