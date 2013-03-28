using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using NewInfo.Resources;

namespace NewInfo
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            begin();
      
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void begin()
        {
            Uri url = new Uri("http://yts0.hkinfohub.kr3.yahoo.com/v0/m/news?channel=1");
            WebClient webClient = new WebClient();
            webClient.OpenReadAsync(url);              //在不阻止调用线程的情况下，从资源返回数据
            webClient.OpenReadCompleted += new OpenReadCompletedEventHandler(complete);
            
        }
        private void complete(Object sender, OpenReadCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                using (System.IO.StreamReader reader = new System.IO.StreamReader(e.Result))
                {
                    string strStream = reader.ReadToEnd();
                    // string subString = Utf8ToGB2312(strStream);

                    progressBar.Visibility = Visibility.Collapsed;
                    MessageBox.Show("下载成功\n" + strStream);
   

                    //    progress1.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                MessageBox.Show(e.Error.Message);
            }
        }
        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}