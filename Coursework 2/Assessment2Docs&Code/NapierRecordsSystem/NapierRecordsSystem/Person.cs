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
    //Person class inheriting from an interface
    //When an item is changed in the grid this tells the class to change the property also. (Sychronized)
    class Person : INotifyPropertyChanged
    {
        //A basic person constructor
        public Person()
        {

        }

        //Person variables.
        public string email;   //Person email.
        private string name;    //Person name.
        private string address; //Person address.

        //This creates an instance of something being changed in the data grid.
        public event PropertyChangedEventHandler PropertyChanged;

        //Setters and getters.
        public string Email
        {
            get { return email; }
            set { email = value;
            this.NotifyPropertyChanged("Email");
                }
            
        }

        public string Name
        {
            get { return name; }
            set { name = value;
            this.NotifyPropertyChanged("Name");
                }
        }

        public string Address
        {
            get { return address; }
            set { address = value;
            this.NotifyPropertyChanged("Address");
                }
        }

        //When this function is called located the changed box and updates it.
        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }



    }   //END OF PERSON CLASS.
}
