using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace NewInfo
{
   public class Info:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string imageURI;
        public string title;
        public string desc;

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, args);
        }

        public string url
        {
            protected set
            {
                if (value != imageURI)
                {
                    imageURI = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("imageURI"));
                }
            }
            get
            {
                return imageURI;
            }
        }
        public string Title
        {
            protected set
            {
                if (value != title)
                {
                    title = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("title"));
                }
            }
            get
            {
                return title;
            }
        }

        public string Desc
        {
            protected set
            {
                if (value != desc)
                {
                    desc = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("desc"));
                }
            }
            get
            {
                return desc;
            }
        }
     
     
    }
}
