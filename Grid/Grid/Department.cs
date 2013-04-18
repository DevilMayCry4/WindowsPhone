using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace Grid
{
    public class Employee
    {
        public string name { get; set; }
        public string age { get; set; }
        public string sex { get; set; }
    }
    public class Department : INotifyPropertyChanged
    {
        public string departName { get; set; }

        private ObservableCollection<Employee> _employess;


        public ObservableCollection<Employee> Employess
        {
            /*get
            {
                if (_employess == null)
                    _employess = new ObservableCollection<Employee>();

                return _employess;
            }
            set
            {
                if (_employess != value)
                {
                    _employess = value;
                    NotifyPropertyChanged("Employess");
                }
            }*/
            get;
            set;
        }

        public Department()
        {
            Employess = new ObservableCollection<Employee>();

            Employee a = new Employee() { name = "a" };

            Employess.Add(a);

            Employee b = new Employee() { name = "b" };

            Employess.Add(b);
             
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }  

    }
}
