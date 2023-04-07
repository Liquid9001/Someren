using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenService
{
    public class ListOfActivitiesService
    {
        ListOfActivitiesDao listOfActivitiesDao = new ListOfActivitiesDao();

        public List<Activities> GetActivities()
        {
            List<Activities> activities = listOfActivitiesDao.GetAllActivities();
            return activities;
        }

        public void AddActivity(Activities activities)
        {
            listOfActivitiesDao.AddActivity(activities);
        }

        public void DeleteActivity(Activities activities) 
        {
            listOfActivitiesDao.DeleteActivity(activities);
        }

        public void UpdateActivity(Activities activities) 
        {
            listOfActivitiesDao.UpdateActivity(activities);
        }
    }
}
