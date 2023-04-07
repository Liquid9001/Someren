using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenService
{
    public class WeeklyTimetableService
    {

        private WeeklyTimetableDao weeklyTimetabledb;


        public WeeklyTimetableService()
        {
            weeklyTimetabledb = new WeeklyTimetableDao();
        }

        public List<WeeklyTimetable> GetActivitiesWeeklyTimetable()
        {
            List<WeeklyTimetable> weeklyTimetables = weeklyTimetabledb.GetActivitiesWeeklyTimetable();
            return weeklyTimetables;
        }


        public List<WeeklyTimetable> GetWeekData(List<WeeklyTimetable> weeklyTimetables, int week)
        {
            List<WeeklyTimetable> weekList = new List<WeeklyTimetable>();
            DateTime mondayOfWeek = FirstDateOfWeek(week);

            foreach (WeeklyTimetable weeklyTimetableRow in weeklyTimetables)
            {
                if ((weeklyTimetableRow.DateOfActivity >= mondayOfWeek) && (weeklyTimetableRow.DateOfActivity <= mondayOfWeek.AddDays(6)))
                {
                    weekList.Add(weeklyTimetableRow);
                }
            }
            return weekList;
        }



        public DateTime FirstDateOfWeek(int weekOfYear)
        {
            DateTime jan1 = new DateTime(2023, 1, 1);
            int nonCountingDate = DayOfWeek.Thursday - jan1.DayOfWeek;

            DateTime firstThursday = jan1.AddDays(nonCountingDate);
            Calendar calendar = CultureInfo.CurrentUICulture.Calendar;
            int firstWeek = calendar.GetWeekOfYear(firstThursday, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);

            if (firstWeek == 1)
            {
                weekOfYear -= 1;
            }

            DateTime date = firstThursday.AddDays(weekOfYear * 7);
            return (date.AddDays(-3));
        }



        
    }
}
