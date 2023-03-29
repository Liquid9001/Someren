using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenService
{
    public class SupervisorService
    {
        private SupervisorDao supervisordb;

        public SupervisorService()
        {
            supervisordb = new();
        }

        public void Assignsupervisor(Teacher teacher, Activities activities)
        {
            supervisordb.AssignSupervisor(teacher, activities);
        }

        public void DeleteSupervisor(Activities activities)
        {
            supervisordb.DeleteSupervisors(activities);
        }

        public List<Supervisor> GetSupervisors()
        {
            List<Supervisor> supervisors = supervisordb.GetAllSupervisors();
            return supervisors;
        }

        public List<Teacher> GetSpecificSupervisors(Activities activity)
        {
            List<Teacher> teachers = supervisordb.GetActivitySupervisors(activity);
            return teachers;
        }
    }
}
