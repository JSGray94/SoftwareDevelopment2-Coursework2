using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

/*
 * Author @40087220
 * Bitbucket: Assessment 2
 * Date Created 13/11/14
 * Last Modified 12/12/14
 * 
 * Staff class contains variables and functions for Staff objects.
 */

namespace NapierRecordsSystem
{
    //Staff class inherits from Person class and the INotifyPropertyChanged.
    class Staff : Person, INotifyPropertyChanged
    {
        //Basic staff constructor.
        public Staff(string stfName, string stfEmail, string stfAddress, int stfPayrollNumber, string stfDepartment, string stfRole)
        {
            //Properties to be entered into the staff constructor.
            Name = stfName;
            Email = stfEmail;
            Address = stfAddress;
            PayrollNumber = stfPayrollNumber;
            Department = stfDepartment;
            Role = stfRole;
        }

        //Initialise variables.
        private int payrollnumber;  //Staff payroll number int variable.
        private string department;  //Staff department string variable.
        private string role;        //Staff role string variable

        //An event handler that takes care of property changes in the wpf application.
        public event PropertyChangedEventHandler PropertyChanged;

        //Setters and getters.
        //NotifyPropertyChanged allows for changing values in the data grid and saves them to the variables in run time.
        public int PayrollNumber
        {
            get { return payrollnumber; }
            set { payrollnumber = value;
            this.NotifyPropertyChanged("PayrollNumber");
                }
        }

        public string Department
        {
            get { return department; }
            set { department = value;
            this.NotifyPropertyChanged("Department");
                }
        }

        public string Role
        {
            get { return role; }
            set { role = value;
            this.NotifyPropertyChanged("Role");
                }
        }

        //A function that sets the value of the current staff being added.
        public void setStaff(string stfName, string stfEmail, string stfAddress, string stfPayrollNumber, string stfDepartment, string stfRole)
        {
            //Add the attributes from the boxes to the staff object.
            this.Name = stfName;
            this.Email = stfEmail;
            this.Address = stfAddress;
            this.PayrollNumber = int.Parse(stfPayrollNumber);
            this.Department = stfDepartment;
            this.Role = stfRole;
        }   //END OF SET STAFF FUNCTION.

        //This function changes the changed value from the original value to the newly entered one.
        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }   //END OF NOTIFYPROPERTYCHANGED FUNCTION.

    }   //END OF STAFF CLASS.
}
