using System;
using System.ComponentModel;
using System.Windows.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json
{
    public class Class1 : INotifyPropertyChanged
    {
        public string jsname;

        public event PropertyChangedEventHandler PropertyChanged;
      
        public Class1()
        {
            jsname = "json";
        }

        public string JsName
        {
            protected set
            {
                if (value != jsname)
                {

                    jsname = value;

                    OnPropertyChanged(new PropertyChangedEventArgs("JsName"));
                    
                }
            }
            get
            {
                return jsname;
            }
        }

        public string convert()
        {
            return string.Format("{0}convert to", JsName);
        }
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, args);
        }

    }
    
}
