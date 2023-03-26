using SomerenModel;
using SomerenService;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace SomerenUI
{
    public partial class SomerenUI : Form
    {

        DateTime startDatum;
        DateTime eindDatum;
        VATService VATService = new VATService();
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
            pnlVAT.Hide();

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
            pnlVAT.Hide();

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
            pnlVAT.Hide();


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
            pnlVAT.Hide();

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
            pnlVAT.Hide();
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
            pnlVAT.Hide();
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
                List<Drink> drinks = CollectDrinks();
                DrinksDisplay(drinks);
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong while loading the students: " + e.Message);
            }
        }
        // adds students to a listview
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

        //adds drinks to a listview
        private void DrinksDisplay(List<Drink> drinks)
        {
            // clear the listview items before filling it
            listViewDrinks.Items.Clear();

            foreach (Drink drink in drinks)
            {
                ListViewItem li = new ListViewItem(drink.Id.ToString());
                li.SubItems.Add(drink.DrinkName);
                li.SubItems.Add(drink.Price.ToString());
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
            DataGridViewRow drinksRow = dataGridViewDrinks.SelectedCells[0].OwningRow;
            Drink drink = new Drink((int)drinksRow.Cells[0].Value, (string)drinksRow.Cells[1].Value, (int)drinksRow.Cells[2].Value, (double)drinksRow.Cells[3].Value, (int)drinksRow.Cells[4].Value);
            DrinksService drinksService = new DrinksService();
            drinksService.UpdateDrink(drink);
            ShowDrinksPanel();
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

        private void VATToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlDashboard.Hide();
            pnlStudents.Hide();
            pnlActivities.Hide();
            pnlRooms.Hide();
            pnlTeacher.Hide();
            pnlDrinks.Hide();
            pnlRevRepo.Hide();
            pnlCashRegister.Hide();

            pnlVAT.Show();


        }

        private void Q1VatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VATData VAT = VATService.getVATData(1);
            VATLabel.Text = "Q1 VAT";
            VATSelectQuarterLabel.Text = "Quarter runs from: 01/01 to: 31/03 for year: 2023";


            VATTotalLabel.Text = $"Total VAT (low tariff, 6%) amount payable: �{VAT.Low.ToString("0.00")} \nTotal VAT(high tariff, 21 %) amount payable: �{VAT.High.ToString("0.00")}\nTotal VAT amount payable: �{(VAT.Low + VAT.High).ToString("0.00")}";


        }

        private void Q2VatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VATData VAT = VATService.getVATData(2);
            VATLabel.Text = "Q2 VAT";
            VATSelectQuarterLabel.Text = "Quarter runs from: 01/04 to: 30/06 for year: 2023";

            VATTotalLabel.Text = $"Total VAT (low tariff, 6%) amount payable: �{VAT.Low.ToString("0.00")} \nTotal VAT(high tariff, 21 %) amount payable: �{VAT.High.ToString("0.00")}\nTotal VAT amount payable: �{(VAT.Low + VAT.High).ToString("0.00")}";

        }

        private void Q3VatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VATData VAT = VATService.getVATData(3);
            VATLabel.Text = "Q3 VAT";
            VATSelectQuarterLabel.Text = "Quarter runs from: 01/07 to: 31/10 for year: 2023";

            VATTotalLabel.Text = $"Total VAT (low tariff, 6%) amount payable: �{VAT.Low.ToString("0.00")} \nTotal VAT(high tariff, 21 %) amount payable: �{VAT.High.ToString("0.00")}\nTotal VAT amount payable: �{(VAT.Low + VAT.High).ToString("0.00")}";
        }

        private void Q4VatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VATData VAT = VATService.getVATData(4);
            VATLabel.Text = "Q4 VAT";
            VATSelectQuarterLabel.Text = "Quarter runs from: 01/10 to: 31/12 for year: 2023";

            VATTotalLabel.Text = $"Total VAT (low tariff, 6%) amount payable: �{VAT.Low.ToString("0.00")} \nTotal VAT(high tariff, 21 %) amount payable: �{VAT.High.ToString("0.00")}\nTotal VAT amount payable: �{(VAT.Low + VAT.High).ToString("0.00")}";
        }

        private List<VATInformation> GetAllVATInformation()
        {

            List<VATInformation> VATInformation = VATService.GetAllVATInformation();

            return VATInformation;

        }

        private void pnlVAT_Paint(object sender, PaintEventArgs e)
        {
        }

        private void CheckOutButton_Click(object sender, EventArgs e)
        {

            try
            {
                DrinkOrderService drinkOrderService = new DrinkOrderService();
                DrinkOrder drinkOrder = new DrinkOrder();
                if (listViewStudents.SelectedItems.Count == 0 && listViewDrinks.SelectedItems.Count == 0)
                {
                    return;
                }
                ListViewItem student = listViewStudents.SelectedItems[0];
                drinkOrder.StudentId = int.Parse(student.Text);
                foreach (ListViewItem drink in listViewDrinks.SelectedItems)
                {
                    drinkOrder.DrinkId = drink.Text;
                    drinkOrderService.AddOrder(drinkOrder);
                    drinkOrderService.UpdateStock(drinkOrder);
                }
                List<Drink> drinks = CollectDrinks();
                DrinksDisplay(drinks);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went Wrong " + ex);
                throw;
            }
        }

        private void listViewDrinks_SelectedIndexChanged(object sender, EventArgs e)
        {
            double total = 0;
            foreach (ListViewItem SelectedDrink in listViewDrinks.SelectedItems)
            {
                total += int.Parse(SelectedDrink.SubItems[2].Text);
            }
            TotalPriceTextBox.Text = total.ToString("\u20AC 0.00");
        }
        private void dataGridViewDrinks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }
        private List<Drink> CollectDrinks()
        {
            DrinkOrderService drinkOrderService = new DrinkOrderService();
            List<Drink> drinks = drinkOrderService.CollectDrinks();
            return drinks;

        }

        // Mohamed Opdracht 4
        private void ShowActivitySupervisor() 
        {
            //Hide other Panels
            pnlStudents.Hide();
            pnlActivities.Hide();
            pnlRevRepo.Hide();
            pnlRooms.Hide();
            pnlTeacher.Hide();
            pnlDrinks.Hide();
            pnlCashRegister.Hide();
            pnlVAT.Hide();
            BackButton.Hide();

            // Hide assign
            lblAssignedSupervisor.Hide();
            lblSelectActivity.Hide();
            lblSelectSupervisorCb.Hide();
            cbAssign.Hide();
            AssignButton.Hide();
            lvAssigned.Hide();
            lvSelectActivity.Hide();

            // Hide Remove
            lblSelectActivityCb.Hide();
            cbRemove.Hide();
            ShowSupervisorButton.Hide();
            lvRemove.Hide();
            RemoveButton.Hide();
            lblRemoveSupervisor.Hide();

            // show main panel
            pnlSupervisor.Show();
        }

        private void ShowActivitySupervisorAssign()
        {
            //Hide other Panels
            pnlStudents.Hide();
            pnlActivities.Hide();
            pnlRevRepo.Hide();
            pnlRooms.Hide();
            pnlTeacher.Hide();
            pnlDrinks.Hide();
            pnlCashRegister.Hide();
            pnlVAT.Hide();

            // hide Remove/Main
            lblSelectActivityCb.Hide();
            cbRemove.Hide();
            ShowSupervisorButton.Hide();
            lvRemove.Hide();
            RemoveButton.Hide();
            lblRemoveSupervisor.Hide();
            lblMainAssign.Hide();
            lblMainRemove.Hide();
            MainAssignButton.Hide();
            MainRemoveButton.Hide();

            // show Assign
            lblAssignedSupervisor.Show();
            lblSelectActivity.Show();
            lblSelectSupervisorCb.Show();
            cbAssign.Show();
            AssignButton.Show();
            lvAssigned.Show();
            lvSelectActivity.Show();
            BackButton.Show();

            cbAssign.SelectedIndex = -1;

            /*try
            {
                List<Activities> activities = GetActivities();
                List<Teacher> teachers = GetTeachers();
                *//*List<Supervisor> supervisors = GetSupervisors();*/

            /*displayActivity(activities);
            displayTeachers(teachers);
            displaySupervisor(supervisors);*//*



        }
        catch (Exception e)
        {
            MessageBox.Show("Something went wrong while loading the activities: " + e.Message);
        }*/
        }

        private void ShowSupervisorButton_Click(object sender, EventArgs e)
        {

        }

        private void MainAssignButton_Click(object sender, EventArgs e)
        {
            ShowActivitySupervisorAssign();
        }

        private void MainRemoveButton_Click(object sender, EventArgs e)
        {

        }

        private void AssignButton_Click(object sender, EventArgs e)
        {

        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {

        }

        private void BackButton_Click(object sender, EventArgs e)
        {

        }

        private void activitySupervisorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowActivitySupervisor();
        }
    }
}