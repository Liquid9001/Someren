using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class WeeklyTimetable
    {
        public int ActivityId { get; set; }         // activity id
        public int ActivityTeacherId { get; set; }
        public int TeacherId { get; set; }     // teacher id
        public DateTime DateOfActivity { get; set; }   // date of activity
        public string Activity { get; set; }      // type of activity

    }
}
