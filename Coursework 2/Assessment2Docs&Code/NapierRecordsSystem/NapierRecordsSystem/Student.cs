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
 * Person class contains variables and functions for Person objects.
 */

namespace NapierRecordsSystem
{
    //Student class inherits from person class and INotifyPropertyChanged interface.
    class Student : Person, INotifyPropertyChanged
    {
        //Basic student object constructor.
        public Student(string stdName, string stdEmail, string stdAddress, int stdMatricNumber)
        {
            Name = stdName;
            Email = stdEmail;
            Address = stdAddress;
            MatricNumber = stdMatricNumber;

        }

        //Second basic student object constructor.
        public Student(string stdName, int stdMatricNumber, int stdMark, string stdStatus)
        {
            Name = stdName;
            MatricNumber = stdMatricNumber;
            Mark = stdMark;
            Status = stdStatus;
        }

        //Initialise students variables.
        private int matricnumber;   //Matriculation number.
        private int mark = -1;      //Holds students mark.
        private string status = "Studying";      //Holds status of the student.

        //An event handler that takes care of property changes in the wpf application.
        public event PropertyChangedEventHandler PropertyChanged;

        //Getters and setters
        public int MatricNumber
        {
            get { return matricnumber; }
            set { matricnumber = value;
            this.NotifyPropertyChanged("MatricNumber");
                }
        }

        public int Mark
        {
            get { return mark; }
            set { mark = value;
            this.NotifyPropertyChanged("Mark");
            if (this.Mark >= 0 && this.Mark < 40)
            {
                this.Status = "Failed";
                this.NotifyPropertyChanged("Status");
            }

            if(this.Mark > 39)
            {
                this.Status = "Passed";
                this.NotifyPropertyChanged("Status");
            }
                }

        }

        public string Status
        {
            get { return status; }
            set { status = value;
            this.NotifyPropertyChanged("Status");
                }
        }

        //A function that sets the value of the current student being enrolled.
        public void setStudent(string stdName, string stdEmail, string stdAddress, string stdMatricNo)
        {
            //Add the attributes from the boxes to the student object.
            this.Name = stdName;
            this.Email = stdEmail;
            this.Address = stdAddress;
            this.MatricNumber = int.Parse(stdMatricNo);
        }

        //This function changes the changed value from the original value to the newly entered one.
        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }


    }   //END OF STUDENT CLASS.
}
