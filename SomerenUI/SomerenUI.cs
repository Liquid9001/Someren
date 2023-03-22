using SomerenService;
using SomerenModel;
using System.Windows.Forms;
using System.Collections.Generic;
using System;

namespace SomerenUI
{
    public partial class SomerenUI : Form
    {
        public SomerenUI()
        {
            InitializeComponent();
        }

        private void ShowDashboardPanel()
        {
            // hide all other panels
            pnlStudents.Hide();
            pnlActivities.Hide();
            pnlRooms.Hide();
            pnlTeacher.Hide();


            // show dashboard
            pnlDashboard.Show();
        }

        private void ShowStudentsPanel()
        {
            // hide all other panels
            pnlDashboard.Hide();
            pnlActivities.Hide();
            pnlRooms.Hide();
            pnlTeacher.Hide();


            // show students
            pnlStudents.Show();

            try
            {
                // get and display all students
                List<Student> students = GetStudents();
                DisplayStudents(students);
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the students: " + e.Message);
            }
        }

        private void ShowActivitiesPanel()
        {
            // hide all other panels
            pnlStudents.Hide();
            pnlDashboard.Hide();
            pnlRooms.Hide();
            pnlTeacher.Hide();

            // show dashboard
            pnlActivities.Show();

            try
            {
                List<Activities> activities = GetActivities();
                DisplayActivities(activities);


            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the activities: " + e.Message);
            }
        }

        private List<Student> GetStudents()
        {
            StudentService studentService = new StudentService();
            List<Student> students = studentService.GetStudents();
            return students;
        }

        private void DisplayStudents(List<Student> students)
        {

            dataGridViewStudents.DataSource = students;

        }


        private List<Activities> GetActivities()
        {
            ActivitiesService activitiesService = new ActivitiesService();
            List<Activities> activities = activitiesService.GetActivities();
            return activities;
        }

        private void DisplayActivities(List<Activities> activities)
        {
            // clear the listview before filling it
            dataGridViewActivities.DataSource = activities;
        }





        private void ShowRoomsPanel()
        {
            pnlDashboard.Hide();
            pnlStudents.Hide();
            pnlActivities.Hide();
            pnlTeacher.Hide();

            pnlRooms.Show();


            try
            {
                List<Room> rooms = GetRooms();
                DisplayRooms(rooms);
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the rooms: " + e.Message);
            }
        }

        private List<Room> GetRooms()
        {
            RoomService roomService = new RoomService();
            List<Room> rooms = roomService.GetAllRooms();
            return rooms;
        }

        private void DisplayRooms(List<Room> rooms)
        {

            dataGridViewRooms.DataSource = rooms;

        }
        private void ShowTeachersPanel()
        {
            // hide all other panels
            pnlDashboard.Hide();
            pnlStudents.Hide();
            pnlActivities.Hide();
            pnlRooms.Hide();
            // show teachers
            pnlTeacher.Show();

            try
            {
                // get and display all teachers
                List<Teacher> teachers = GetTeachers();
                DisplayTeachers(teachers);
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the teachers: " + e.Message);
            }
        }
        private List<Teacher> GetTeachers()
        {
            TeacherService teacherService = new TeacherService();
            List<Teacher> teachers = teacherService.GetTeachers();
            return teachers;
        }
        private void DisplayTeachers(List<Teacher> teachers)
        {
            dataGridViewTeacher.DataSource = teachers;
        }
      
       

        

        

        

        private void dashboardToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            ShowDashboardPanel();
        }

        private void studentsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ShowStudentsPanel();
        }

        private void lecturersToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ShowTeachersPanel();
        }

        private void activitiesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ShowActivitiesPanel();
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowRoomsPanel();
        }

        
    }
}