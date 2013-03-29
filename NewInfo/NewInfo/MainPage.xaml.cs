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

namespace NewInfo
{
    public class Info
    {
        public string imageURI;
        public string title;
        public string desc;
    }
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
                        XElement element = XElement.Parse(strStream);
                        int count = 0;
                        foreach (XElement item in element.Elements("item"))
                        {
                            if (count < 9)
                            {
                                XElement imageElement = item.Element("image");
                                ImageBrush imageBrush = new ImageBrush();
                                imageBrush.ImageSource = new BitmapImage(new Uri((imageElement.Element("url").Value)));

                                Image image = new Image();
                                double imageWidth = (BackCanvas.ActualWidth - 10 * 4) / 3;
                                double imageHeight = (BackCanvas.ActualHeight - 10 * 4) / 3;

                                Button button = new Button();
                                button.Width = imageWidth;
                                button.Height = imageHeight;
                                button.Background = imageBrush;
                                button.Tag = count;
                                button.Click +=button_Click;
                                Canvas.SetLeft(button, 10 + (imageWidth + 10) * (count % 3));
                                Canvas.SetTop(button, 10 + (imageHeight + 10) * (count / 3));
                                BackCanvas.Children.Add(button);


                                image.Width = imageWidth;
                                image.Height = imageHeight;
                                

                                SolidColorBrush brush = new SolidColorBrush();
                                brush.Color = Colors.Red;

                                TextBlock textBlock = new TextBlock();
                                textBlock.Width = imageWidth;
                                textBlock.Height = 40;
                                textBlock.Foreground = brush;
                                textBlock.VerticalAlignment = VerticalAlignment.Center;
                                textBlock.TextTrimming = TextTrimming.WordEllipsis;
                           
                                Canvas.SetLeft(textBlock, 22 + (imageWidth + 10) * (count % 3));
                                Canvas.SetTop(textBlock, (count/3+1)*(10 + imageHeight ) - textBlock.Height );
                                BackCanvas.Children.Add(textBlock);
                                textBlock.Text = item.Element("title").Value;
                                textBlock.FontSize = 25;
                                textBlock.TextTrimming = TextTrimming.WordEllipsis;

                                Info info = new Info();
                                info.title = item.Element("title").Value;
                                info.imageURI = imageElement.Element("url").Value;
                                info.desc = item.Element("description").Value;
                                list.Add(info);

                                count++;
                            }
                            else
                            {
                                break;
                            }
                            // MessageBox.Show(item.Element("title").Value);
                        }


                    }
                }
                else
                {
                    MessageBox.Show(e.Error.Message);
                }

            });

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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Visibility = Visibility.Collapsed;
            progressBar.Visibility = Visibility.Visible;
            Thread thread = new Thread(begin);
            thread.Start();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
           /* int tag = (int)((Button)sender).Tag;
            Info info = list[tag];
            MessageBox.Show(info.desc);*/
             
            NavigationService.Navigate(new Uri("/DetailPage.xaml", UriKind.Relative));


        }
    }
}