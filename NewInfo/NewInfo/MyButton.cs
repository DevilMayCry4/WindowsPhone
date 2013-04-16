using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace CustomButton
{
   public class MyButton:Button
    {
        public static readonly DependencyProperty imageSourceProperty =
            DependencyProperty.Register("imageSource", typeof(ImageSource), typeof(MyButton), null);

        public ImageSource imageSource
        {
            get { return (ImageSource)GetValue(imageSourceProperty); }
            set { SetValue(imageSourceProperty, value); }

        }

        public static readonly DependencyProperty textProperty =
            DependencyProperty.Register("text", typeof(string), typeof(MyButton), null);
        public string text
        {
            get { return (string)GetValue(textProperty); }
            set { SetValue(textProperty, value); }
        }

       
    }
}
