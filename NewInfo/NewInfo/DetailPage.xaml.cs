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
using Phone.Controls;

namespace NewInfo
{
    public partial class DetailPage : PhoneApplicationPage
    {
        Info info;
        public DetailPage()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            
            base.OnNavigatedTo(e);
            info = (Application.Current as App).info;
            titleBlock.DataContext = info;
            descBlock.Text = info.desc;
            image.DataContext = info;
           //titleBlock.Text = info.title;
           //descBlock.Text = info.desc;
           ///image.Source = new BitmapImage(new Uri(info.imageURI, UriKind.RelativeOrAbsolute));
             
        }
    }
}