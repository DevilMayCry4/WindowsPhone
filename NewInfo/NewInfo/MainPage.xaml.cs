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
             

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
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
                        
                        listBox.SelectionChanged +=listBox_SelectionChanged;


                        XElement element = XElement.Parse(strStream);
                        int count = 0;
                        foreach (XElement item in element.Elements("item"))
                        {
                            Canvas canvas = new Canvas();
                            canvas.Height = 120;
                            ListBoxItem listItem = new ListBoxItem();
                            listItem.Content = canvas;

                            
                             
                                XElement imageElement = item.Element("image");
                                ImageBrush imageBrush = new ImageBrush();
                                imageBrush.ImageSource = new BitmapImage(new Uri((imageElement.Element("url").Value)));
                              
                                Image image = new Image();
                                double imageWidth =  100;
                                double imageHeight = 100;
                                image.Source = new BitmapImage(new Uri((imageElement.Element("url").Value)));
                          
                                
                                Button button = new Button();
                                button.Width = imageWidth;
                                button.Height = imageHeight;
                                button.Background = imageBrush;
                                button.Tag = count;
                                button.Click +=button_Click;
                                Canvas.SetLeft(button, 10);
                                Canvas.SetTop(button,10);
                                canvas.Children.Add(image);
                                

                                image.Width = imageWidth;
                                image.Height = imageHeight;
                                

                                SolidColorBrush brush = new SolidColorBrush();
                                brush.Color = Colors.Red;

                                TextBlock textBlock = new TextBlock();
                                textBlock.Width = imageWidth;
                                textBlock.Height = 40;
                                textBlock.Width = 480 - 120;
                                Debug.WriteLine("{0}",textBlock.Width);
                                textBlock.Foreground = brush;
                                textBlock.VerticalAlignment = VerticalAlignment.Center;
                                textBlock.TextWrapping = TextWrapping.Wrap;
                               // textBlock.TextTrimming = TextTrimming.WordEllipsis;
                           
                                Canvas.SetLeft(textBlock,120);
                                Canvas.SetTop(textBlock,10);
                                
                                textBlock.Text = item.Element("title").Value;
                                textBlock.FontSize = 25;
                                textBlock.TextTrimming = TextTrimming.WordEllipsis;
                                canvas.Children.Add(textBlock);

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

        private void listBox_SelectionChanged(object sender, RoutedEventArgs e)
        {

            Debug.WriteLine("{0}", (sender as ListBox).SelectedIndex);
            int tag = (sender as ListBox).SelectedIndex;
            (Application.Current as App).info = list[tag];


            NavigationService.Navigate(new Uri("/DetailPage.xaml", UriKind.Relative));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            int tag = (int)((Button)sender).Tag;
            (Application.Current as App).info = list[tag];
         
           
            NavigationService.Navigate(new Uri("/DetailPage.xaml", UriKind.Relative));
        }
    }
}