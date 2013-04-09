using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using NewInfo;
using System.Windows.Media.Imaging;

namespace NewInfo
{
    public partial class DetailPage : PhoneApplicationPage
    {
        public DetailPage()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            Info info;  
            base.OnNavigatedTo(e);
            info = (Application.Current as App).info;
      
           titleBlock.Text = info.title;
           descBlock.Text = info.desc;
           image.Source = new BitmapImage(new Uri(info.imageURI, UriKind.RelativeOrAbsolute));
             
        }
    }
}