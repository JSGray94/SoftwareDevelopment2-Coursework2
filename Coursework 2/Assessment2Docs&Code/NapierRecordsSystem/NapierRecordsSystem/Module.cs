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
 * Module class contains variables and functions for Module objects.
 */

namespace NapierRecordsSystem
{
    //Module class inherits from INotifyPropertyChange interface.
    class Module : INotifyPropertyChanged
    {

        //Initialise variables.
        private string modulecode;  //Module code.
        private string modulename;  //Module name.
        private Staff moduleleader; //Module leader staff object.

        //An event handler that takes care of property changes in the wpf application.
        public event PropertyChangedEventHandler PropertyChanged;

        //Sets the values of the modules.
        public void setModule(string modName, string modCode, Staff modLeader)
        {
            //Add the attributes from the boxes to the module object.
            this.ModuleName = modName;
            this.ModuleCode = modCode;
            this.ModuleLeader = modLeader;
        }

        //Setters and getters.
        public string ModuleCode
        {
            get { return modulecode; }
            set { modulecode = value; }
        }
        public string ModuleName
        {
            get { return modulename; }
            set { modulename=value; }
        }
        public Staff ModuleLeader
        {
            get { return moduleleader; }
            set { moduleleader=value;
            this.NotifyPropertyChanged("ModuleLeader");
                }
            
        }


        //This function changes the changed value from the original value to the newly entered one.
        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

    }   //END OF MODULE CLASS.
}
