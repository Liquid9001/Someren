using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenService
{
    public class ActivitiesService
    {
        private ActivitiesDao activitiesdb;

        public ActivitiesService()
        {
            activitiesdb = new();
        }

        public List<Activities> GetActivities()
        {
            List<Activities> activities = activitiesdb.GetAllActivities();
            return activities;
        }
    }
}
