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
using System.Xml.Linq;
using System.Windows.Media.Imaging;
using System.Threading;
using System.Windows.Media;
using NewInfo;
using System.Diagnostics;
using CustomButton;

namespace NewInfo
{
    
    public partial class MainPage : PhoneApplicationPage
    {
        List<Info> list;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            progressBar.Visibility = Visibility.Collapsed;
     
        }

        

        private void begin()
        {
            Debug.WriteLine("begin");
            Uri url = new Uri("http://yts0.hkinfohub.kr3.yahoo.com/v0/m/news?channel=1");
            WebClient webClient = new WebClient();
            webClient.OpenReadAsync(url);              
            webClient.OpenReadCompleted += new OpenReadCompletedEventHandler(complete);

        }
        private void complete(Object sender, OpenReadCompletedEventArgs e)
        {
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
               

               
                list = new List<Info>();

                if (e.Error == null)
                {
                    using (System.IO.StreamReader reader = new System.IO.StreamReader(e.Result))
                    {                        
                        string strStream = reader.ReadToEnd();
                        progressBar.Visibility = Visibility.Collapsed;
                        ListBox listBox = new ListBox();
                        Content = listBox;
                        
                       


                        XElement element = XElement.Parse(strStream);
                        int count = 0;
                        foreach (XElement item in element.Elements("item"))
                        {
                             

                            XElement imageElement = item.Element("image");
                            
                            MyButton myButton = new MyButton();
                            myButton.imageSource = new BitmapImage(new Uri((imageElement.Element("url").Value)));
                            myButton.text = item.Element("title").Value;
                            myButton.Width = 480;
                            myButton.Height = 120;
                            myButton.Tag = count;
                            myButton.Click += button_Click;

                            ListBoxItem listItem = new ListBoxItem();
                            listItem.Content = myButton;
  
                                Info info = new Info();
                                info.title = item.Element("title").Value;
                                info.imageURI = imageElement.Element("url").Value;
                                info.desc = item.Element("description").Value;
                                list.Add(info);
                                listBox.Items.Add(listItem);
                                count++;
                            
                            
                        }


                    }
                }
                else
                {
                    MessageBox.Show(e.Error.Message);
                }

            });

          
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            (sender as Button).Visibility = Visibility.Collapsed;
            progressBar.Visibility = Visibility.Visible;
            this.begin();
      
        }

         

        private void button_Click(object sender, RoutedEventArgs e)
        {
            Button box = (Button)sender;
            int tag =(int)box.Tag;
            (Application.Current as App).info = list[tag];
            NavigationService.Navigate(new Uri("/DetailPage.xaml", UriKind.Relative));
        }
    }
}