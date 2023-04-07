using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenDAL;
using SomerenModel;

namespace SomerenService
{
    public class StudentParticipatingService
    {

        private ParticipatingStudentsDao participatingStudentsdb;


        public StudentParticipatingService()
        {
            participatingStudentsdb = new ParticipatingStudentsDao();
        }

        public List<StudentParticipating> GetAllParticipatingStudents()
        {
            List<StudentParticipating> studentsParticipating = participatingStudentsdb.GetAllParticipatingStudents();
            return studentsParticipating;
        }

    }
}

