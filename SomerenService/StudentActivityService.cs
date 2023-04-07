using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SomerenDAL;
using SomerenModel;

namespace SomerenService
{
    public class StudentActivityService
    {
        private StudentActivityDao studentActivitydb;

        public StudentActivityService()
        {
            studentActivitydb = new();
        }
        public List<ActivityStudent> GetAllStudentsActivity()
        {
            List<ActivityStudent> activityStudents = studentActivitydb.GetAllStudentsActivity();
            return activityStudents;
        }
        public void RemoveStudentActivity(ActivityStudent students)
        {
            studentActivitydb.RemoveStudentActivity(students);
        }

        public void AddStudentActivity(Student student, Activities activities)
        {
            studentActivitydb.AddStudentActivity(student, activities);
        }
    }
}
