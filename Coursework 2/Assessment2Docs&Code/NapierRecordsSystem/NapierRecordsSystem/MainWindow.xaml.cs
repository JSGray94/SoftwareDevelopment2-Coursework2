using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.ComponentModel;

/*
 * Author @40087220
 * Bitbucket: Assessment 2
 * Date Created 12/11/14 @ 00:00
 * Last Modified 12/12/14
 */

namespace NapierRecordsSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    //Main window class determines GUI's contents.
    public partial class MainWindow : Window
    {
        //Create an empty list that stores students.
        BindingList<Student> StudentList = new BindingList<Student>();

        //Creates a staff list for staff objects to be added to.
        BindingList<Staff> StaffList = new BindingList<Staff>();

        //Create a list that holds details about students on the Database Systems module.
        BindingList<Student> DatabaseList = new BindingList<Student>();

        //Create a list that holds details about students on the Systems and Services Module.
        BindingList<Student> SystemsAndServicesList = new BindingList<Student>();

        //Creates a list that holds details about students on the Software Development Module.
        BindingList<Student> SoftwareDevelopmentList = new BindingList<Student>();

        //Creates a list that holds details about all modules. It's name, module code and module leader.
        BindingList<Module> ModuleList = new BindingList<Module>();

        //Creates a module object for the Database Systems module.
        Module DatabaseSystems = new Module();
        //Creates a module object for the Systems and Services Module.
        Module SystemsAndServices = new Module();
        //Creates a module object for the Software Development module.
        Module SoftwareDevelopment = new Module();


        public MainWindow()
        {
            InitializeComponent();

            //Adds a default student object to the student list when the program initialises.
            StudentList.Add(new Student("Jordan Gray", "GrayboStephano@gmail.com", "17/3 Ferniehill Drive", 1234));
            //Binds grid to the student list.
            StudentDataGrid.ItemsSource = StudentList;
            //Turn off auto generate columns.
            StudentDataGrid.AutoGenerateColumns = false;

            //Adding the custom columns I want shown in the student data grid in the desired order. (Matric Number, Name, Email and Address. Omits Mark and Status.)
            StudentDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Matric Number", Binding = new System.Windows.Data.Binding("MatricNumber") });
            StudentDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Name", Binding = new System.Windows.Data.Binding("Name") });
            StudentDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Email", Binding = new System.Windows.Data.Binding("Email") });
            StudentDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Address", Binding = new System.Windows.Data.Binding("Address") });

            //Create 3 staff objects to become the default module leaders.
            //Creates a staff object.
            //Is the Database Systems Module Leader.
            Staff DatabaseLeader = new Staff("Brian Davison", "b.davison@napier.ac.uk", "88 Sheffield Road", 9001, "Database Systems", "Lecturer");
            //Creates a staff object.
            //Is the Systems and Services Module Leader.
            Staff SystemsAndServicesLeader = new Staff("Jim Jackson", "j.jackson@napier.ac.uk", "22 Humbug Avenue", 9201, "Systems and Services", "Lecturer");
            //Creates a staff object.
            //Is the Software Development Module Leader.
            Staff SoftwareDevelopmentLeader = new Staff("Neil Urquhart", "n.urquhart@napier.ac.uk", "77 Madeups Ville", 9567, "Software Development", "Professor");
            


            //Create the initial 3 modules.
            //Adds the database module leader to the staff list.
            //Sets the attributes for the module.
            //Adds the Database Systems module to the module list (Contains the staff leader.)
            StaffList.Add(DatabaseLeader);
            DatabaseSystems.setModule("Database Systems", "INFO123", DatabaseLeader);
            ModuleList.Add(DatabaseSystems);
            //Adds the Systems and Services module leader to the staff list.
            //Sets the attributes for the module.
            //Adds the Systems and services module to the module list. (Contains the staff leader.)
            StaffList.Add(SystemsAndServicesLeader);
            SystemsAndServices.setModule("Systems and Services", "MMRR678", SystemsAndServicesLeader);
            ModuleList.Add(SystemsAndServices);
            //Adds the Software Development module leader to the staff list.
            //Sets the attributes for the module.
            //Adds the Software Development module to the module list. (Contains the staff leader.)
            StaffList.Add(SoftwareDevelopmentLeader);
            SoftwareDevelopment.setModule("Software Development", "UWOT789", SoftwareDevelopmentLeader);
            ModuleList.Add(SoftwareDevelopment);

            //Binds the data in the staff list to the data grid.
            StaffDataGrid.ItemsSource = StaffList;
            //Turn off auto generate columns.
            StaffDataGrid.AutoGenerateColumns = false;

            //Adding custom columns I want in a specific order for the staff data grid.
            StaffDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Payroll Number", Binding = new System.Windows.Data.Binding("PayrollNumber") });
            StaffDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Name", Binding = new System.Windows.Data.Binding("Name") });
            StaffDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Email", Binding = new System.Windows.Data.Binding("Email") });
            StaffDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Address", Binding = new System.Windows.Data.Binding("Address") });
            StaffDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Department", Binding = new System.Windows.Data.Binding("Department") });
            StaffDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Role", Binding = new System.Windows.Data.Binding("Role") });



            //Selecting the source for the database list.
            DatabaseDataGrid.ItemsSource = DatabaseList;
            //Turn off auto generate columns.
            DatabaseDataGrid.AutoGenerateColumns = false;

            //Adding custom columns shown in the database list in desired order. (Name, Mark and Status.)
            DatabaseDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Student Name", Binding = new System.Windows.Data.Binding("Name") });
            DatabaseDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Mark", Binding = new System.Windows.Data.Binding("Mark") });
            DatabaseDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Status", Binding = new System.Windows.Data.Binding("Status") });

            //Selecting the item source for the system and services list.
            SaSDataGrid.ItemsSource = SystemsAndServicesList;
            //Turn off auto generate columns.
            SaSDataGrid.AutoGenerateColumns = false;

            //Adding custom columns shown in the database list in desired order. (Name, mark and status.)
            SaSDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Student Name", Binding = new System.Windows.Data.Binding("Name") });
            SaSDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Mark", Binding = new System.Windows.Data.Binding("Mark") });
            SaSDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Status", Binding = new System.Windows.Data.Binding("Status") });

            //Selecting the source for the database list.
            SD2DataGrid.ItemsSource = SoftwareDevelopmentList;
            //Turn off auto generate columns.
            SD2DataGrid.AutoGenerateColumns = false;

            //Adding custom columns shown in the database list in desired order. (Name, mark and status.)
            SD2DataGrid.Columns.Add(new DataGridTextColumn() { Header = "Student Name", Binding = new System.Windows.Data.Binding("Name") });
            SD2DataGrid.Columns.Add(new DataGridTextColumn() { Header = "Mark", Binding = new System.Windows.Data.Binding("Mark") });
            SD2DataGrid.Columns.Add(new DataGridTextColumn() { Header = "Status", Binding = new System.Windows.Data.Binding("Status") });


            //Add the three module names to the combo box for the user to choose from.
            ModuleComboBox.Items.Add("Database Systems");
            ModuleComboBox.Items.Add("Systems and Services");
            ModuleComboBox.Items.Add("Software Development");

            
            //Turn off auto generate columns.
            AllModuleDataGrid.AutoGenerateColumns = false;

            //Adding custom columns to be shown in the all module data grid in desired order. (Module code, module title and module leader.)
            AllModuleDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Module Code", Binding = new System.Windows.Data.Binding("ModuleCode") });
            AllModuleDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Module Title", Binding = new System.Windows.Data.Binding("ModuleName") });
            AllModuleDataGrid.Columns.Add(new DataGridTextColumn() { Header = "Module Leader", Binding = new System.Windows.Data.Binding("ModuleLeader.Name") });

            //Bind the data source of the module data grid to the module list.
            AllModuleDataGrid.ItemsSource = ModuleList;

        }   //END OF MAIN WINDOW CONSTRUCTOR
        


        //An event handler that handles all of the button clicks on the main application page.
        private void EnrollButton_ClearButton_SetStaffButton_ClearStaffButton_AddToModuleButton_StudentModRemoveButton_Click(object sender, RoutedEventArgs e)
        {
            // STAFF //

            //Sets the details entered into the text boxes as the current staff members details.
            if (sender == SetStaffButton)   //If the set staff button is clicked.
            {
                //A data Range check to make sure correct values hve been entered into each textbox.
                if (StaffNameBox.Text == "" || StaffEmailBox.Text == "" || StaffAddressBox.Text == "" || DepartmentBox.Text == "" || RoleBox.Text == "" || PayrollNoBox.Text == "")
                {
                    //Display an error message box.
                    MessageBox.Show("You have left one or more fields blank. Please enter values in all of the fields.");
                }
                else
                {
                    //Range checks payroll number.
                    if (int.Parse(PayrollNoBox.Text) < 9000 || int.Parse(PayrollNoBox.Text) > 9999)
                    {
                        MessageBox.Show("You have entered a payroll number that is not within the range (9000 - 9999). Re-enter.");
                    }
                    else
                    {
                        //Add this newly created staff to the staff list to then be added to the staff data grid.
                        StaffList.Add(new Staff(StaffNameBox.Text, StaffEmailBox.Text, StaffAddressBox.Text, int.Parse(PayrollNoBox.Text), DepartmentBox.Text, RoleBox.Text));
                    }
                }

            }   //END OF ADD STAFF BUTTON


            //Clears the currently entered details in the staaff details boxes.
            if(sender == ClearStaffButton)
            {
                //Clear the contents of the staff detail boxes.
                StaffNameBox.Clear();
                StaffAddressBox.Clear();
                StaffEmailBox.Clear();
                PayrollNoBox.Clear();
                DepartmentBox.Clear();
                RoleBox.Clear();

            }   //END OF CLEAR STAFF BUTTON



            //STUDENT//

            //If the Enroll Button is clicked this method is carried out.
            //This will create a new student object and add it to the student list.
            //Any details entered into the textboxes will be saved to the current student object.
            //The students in the student list will be saved to a Student.txt file in the debug folder.
            if(sender == EnrollButton)
            {
                //A range check to make sure non of the fields are blank.
                if (StudentNameBox.Text == "" || StudentEmailBox.Text == "" || StudentAddressBox.Text == "" || MatricnoBox.Text == "")
                {
                    MessageBox.Show("You have left one or more of the fields blank. Please enter values.");

                }
                else
                {
                     if(int.Parse(MatricnoBox.Text) >= 1000 && int.Parse(MatricnoBox.Text) <= 9000)
                    {
                        //Add this newly created student to the student list.
                        StudentList.Add(new Student(StudentNameBox.Text, StudentEmailBox.Text, StudentAddressBox.Text, int.Parse(MatricnoBox.Text)));
                    }
                    else
                    {
                        MessageBox.Show("The matriculation number box contains incorrect values. Enter within 1000 and 9000.");
                    }

                }

            }   //END OF ENROLL STUDENT BUTTON

            //A clear button to clear the contents in the student detail boxes.
            if(sender == ClearButton)
            {
                //Clear all student details in the text boxes.
                StudentNameBox.Clear();
                StudentEmailBox.Clear();
                StudentAddressBox.Clear();
                MatricnoBox.Clear();

            }   //END OF CLEAR STUDENT DETAILS BUTTON



            //MODULES//

            //This function is carried out when the add to module button is clicked.
            //This takes the student selected from the combo box and adds that student to the selected module in the second combo box.
            if(sender == AddToModuleButton)
            {
                //This searches through the student list for a students name that is equal to the student combo box selection.
                Student search = StudentList.FirstOrDefault(z => z.Name == StudentCNameBox.Text);
                
                //If the name typed into the text box (studentCNameBox) is found then this is carried out.
                if (search != null) //If search is not equal to null.
                {
                    //If the user selects Database Systems in the combo box when clicking the add button.
                    if(ModuleComboBox.SelectedItem == "Database Systems")
                    {
                        //Add the student from the student list whos name matches the name in the textbox to the selected module.
                        DatabaseList.Add(new Student(search.Name, search.MatricNumber, search.Mark, search.Status));
                    }

                    //If the user selects Systems and Services in the combo box when clicking the add button.
                    if (ModuleComboBox.SelectedItem == "Systems and Services")
                    {
                        //Add the student from the student list whos name matches the name in the textbox to the selected module.
                        SystemsAndServicesList.Add(new Student(search.Name, search.MatricNumber, search.Mark, search.Status));
                    }

                    //If the user selects Software Development in the combo box when clicking the add button.
                    if (ModuleComboBox.SelectedItem == "Software Development")
                    {
                        //Add the student from the student list whos name matches the name in the textbox to the selected module.
                        SoftwareDevelopmentList.Add(new Student(search.Name, search.MatricNumber, search.Mark, search.Status));
                    }
                    
                }


            }   //END OF ADD STUDENT TO MODULE BUTTON

            //A button that allows for the removal of a student from a specific module.
            if (sender == StudentModRemoveButton)   //If the Remove Student button is clicked.
            {
                //This searches through the student list for a students name that is equal to the string entered into the StudentCNamebox.
                //Sets this object to look.
                Student look = StudentList.FirstOrDefault(z => z.Name == StudentCNameBox.Text);

                //If the name is found then this is carried out.
                if (look != null)
                {
                    //If the Database Systems option is selected in the combo box.
                    if (ModuleComboBox.SelectedItem == "Database Systems")
                    {
                        //Remove the student from the database list.
                        //Creates a variable called itemToRemove and sets its values to equal the name entered in the textbox.
                        //For each instance of that item in the list, it is removed from the list.
                        var itemToRemove = DatabaseList.Where(z => z.Name == look.Name).ToList();
                        foreach (var item in itemToRemove)
                        {
                            DatabaseList.Remove(item); // Removes each instance of that student within the given module list.
                        }
                    }

                    //If the Systems and Services option is selected in the module combo box and the remove student is clicked...
                    if (ModuleComboBox.SelectedItem == "Systems and Services")
                    {
                        //Remove the student from the database list.
                        //Creates a variable called itemToRemove and sets its values to equal the name entered in the textbox.
                        var itemToRemove = SystemsAndServicesList.Where(z => z.Name == look.Name).ToList();
                        foreach (var item in itemToRemove)
                        {
                            SystemsAndServicesList.Remove(item); // Removes each instance of that student within the given module list.
                        }

                    }

                    //If the Software Development option is selected in the combo box and the remove student button is clicked...
                    if (ModuleComboBox.SelectedItem == "Software Development")
                    {
                        //Remove the student from the software development list.
                        //Creates a variable called itemToRemove and sets its values to equal the name entered in the textbox.
                        var itemToRemove = SoftwareDevelopmentList.Where(z => z.Name == look.Name).ToList();
                        foreach (var item in itemToRemove)
                        {
                            SoftwareDevelopmentList.Remove(item); // Removes each instance of that student within the given module list.
                        }

                    }

                }

            }   //END OF STUDENT REMOVE BUTTON

        



        }   //END OF BUTTON EVENT HANDLER

    }   //END OF MAIN CLASS

}   //END OF NAMESPACE
