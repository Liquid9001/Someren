using SomerenService;
using SomerenModel;
using System.Windows.Forms;
using System.Collections.Generic;
using System;

namespace SomerenUI
{
    public partial class SomerenUI : Form
    {
        DateTime startDatum;
        DateTime eindDatum;
        public SomerenUI()
        {
            InitializeComponent();
        }
        private void ShowDashboardPanel()
        {
            // hide all other panels
            pnlStudents.Hide();
            pnlActivities.Hide();
            pnlRevRepo.Hide();
            pnlRooms.Hide();
            pnlTeacher.Hide();
            pnlDrinks.Hide();
            pnlCashRegister.Hide();

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
            pnlDrinks.Hide();
            pnlCashRegister.Hide();

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
            pnlDrinks.Hide();
            pnlCashRegister.Hide();

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
            pnlDrinks.Hide();
            pnlCashRegister.Hide();

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
            pnlDrinks.Hide();
            pnlCashRegister.Hide();
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
        private void ShowDrinksPanel()
        {
            // hide all other panels
            pnlDashboard.Hide();
            pnlStudents.Hide();
            pnlActivities.Hide();
            pnlRooms.Hide();
            pnlTeacher.Hide();
            pnlCashRegister.Hide();
            // show drinks
            pnlDrinks.Show();

            try
            {
                // get and display all Drinks
                List<Drink> drinks = GetDrinks();
                DisplayDrinks(drinks);
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the drinks: " + e.Message);
            }
        }
        private List<Drink> GetDrinks()
        {
            DrinksService drinkService = new DrinksService();
            List<Drink> drinks = drinkService.GetDrinks();
            return drinks;
        }
        private void DisplayDrinks(List<Drink> drinks)
        {
            dataGridViewDrinks.DataSource = drinks;
        }
        private void submitDate()
        {
            startDatum = DateTime.Parse(Startdate.SelectionRange.Start.ToShortDateString());

            eindDatum = DateTime.Parse(endDate.SelectionRange.Start.ToShortDateString());

            if (startDatum < eindDatum)
            {
                lblDateRange.Text = ($"Selected period: {startDatum.ToString("dd/MM/yyyy")} - {eindDatum.ToString("dd/MM/yyyy")}");

                try
                {
                    List<Revenue> revenues = GetSales();
                    displayRev(revenues);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong while loading the activities: " + e.Message);
                }

            }
            else
            {
                MessageBox.Show("Invalid Period: 'Start' Date must be before 'End' date");
            }

        }
        private List<Revenue> GetSales()
        {
            RevenueService revenueService = new();
            List<Revenue> revenues = revenueService.GetRangeDate(startDatum, eindDatum);
            return revenues;
        }

        private void displayRev(List<Revenue> Sales)
        {

            try
            {
                Sales = GetSales();

            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the activities: " + e.Message);
            }

            lvRev.Items.Clear();

            foreach (Revenue rev in Sales)
            {
                ListViewItem item = new ListViewItem(rev.numberOfCustomer.ToString());
                item.SubItems.Add(rev.turnOver.ToString("0.00"));
                item.SubItems.Add(rev.sales.ToString());
                lvRev.Items.Add(item);
            }

            lvRev.Show();

        }

        private void ShowCashRegisterPanel()
        {
            // hide all other panels
            pnlDashboard.Hide();
            pnlActivities.Hide();
            pnlRooms.Hide();
            pnlTeacher.Hide();
            pnlDrinks.Hide();
            pnlStudents.Hide();
            pnlVAT.Hide();
            pnlDrinks.Hide();
            pnlRevRepo.Hide();

            // show Cash Register panel
            pnlCashRegister.Show();

            try
            {
                // get and display all students
                List<Student> students = GetStudents();
                StudentsDisplay(students);

                // get and display all Drinks
                List<Drink> drinks = GetDrinks();
                DrinksDisplay(drinks);
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the students: " + e.Message);
            }
        }

        private void StudentsDisplay(List<Student> students)
        {
            // clear the listview items before filling it
            listViewStudents.Items.Clear();

            foreach (Student student in students)
            {
                ListViewItem li = new ListViewItem(student.Id.ToString());
                li.SubItems.Add(student.FullName);
                li.Tag = student;   // link student object to listview item
                listViewStudents.Items.Add(li);
            }
        }


        private void DrinksDisplay(List<Drink> drinks)
        {
            // clear the listview items before filling it
            listViewDrinks.Items.Clear();

            foreach (Drink drink in drinks)
            {
                ListViewItem li = new ListViewItem(drink.Id.ToString());
                li.SubItems.Add(drink.DrinkName);
                li.SubItems.Add("\u20AC " + drink.Price.ToString());
                li.SubItems.Add(drink.Stock.ToString());
                li.Tag = drink;   // link student object to listview item
                listViewDrinks.Items.Add(li);
            }
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
        private void DrinkSuppliesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDrinksPanel();
        }
        private void buttonUpdateDrink_Click(object sender, EventArgs e)
        {

        }



        private void RevenueReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlDashboard.Hide();
            pnlStudents.Hide();
            pnlActivities.Hide();
            pnlRooms.Hide();
            pnlTeacher.Hide();
            pnlDrinks.Hide();
            pnlVAT.Hide();
            pnlCashRegister.Hide();

            pnlRevRepo.Show();

            Startdate.MaxSelectionCount = 1;
            Startdate.MaxDate = DateTime.Now;
            endDate.MaxSelectionCount = 1;
            endDate.MaxDate = DateTime.Now;
            lvRev.Hide();
        }
        private void Submit_Click(object sender, EventArgs e)
        {
            submitDate();

        }

        private void CashRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowCashRegisterPanel();
        }
    }
}