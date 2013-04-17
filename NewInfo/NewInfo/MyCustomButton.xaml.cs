using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;

namespace NewInfo
{
    public partial class MyCustomButton : UserControl
    {
        public MyCustomButton()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty imageSourceProperty =
           DependencyProperty.Register("imageSource", typeof(ImageSource), typeof(MyCustomButton), null);

        public ImageSource imageSource
        {
            get { return (ImageSource)GetValue(imageSourceProperty); }
            set { SetValue(imageSourceProperty, value); }

        }

        public static readonly DependencyProperty textProperty =
            DependencyProperty.Register("text", typeof(string), typeof(MyCustomButton), null);
        public string text
        {
            get { return (string)GetValue(textProperty); }
            set { SetValue(textProperty, value); }
        }
    }
}
