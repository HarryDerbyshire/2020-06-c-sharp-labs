using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RadioApp;

namespace RadioGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        Radio aRadio = new Radio();

        //public void RadioMethod()
        //{
        //    if (aRadio.IsOn)
        //    {
        //        if(Channel1.IsChecked == true)
        //        {
        //            aRadio.Channel = 1;
        //        }
        //        else if (Channel2.IsChecked == true)
        //        {
        //            aRadio.Channel = 2;
        //        }
        //        else if (Channel3.IsChecked == true)
        //        {
        //            aRadio.Channel = 3;
        //        }
        //        else if (Channel4.IsChecked == true)
        //        {
        //            aRadio.Channel = 4;
        //        }
        //        LabelChannel.Content = aRadio.Play();
        //    }
        //}

        private void Channel1_Checked(object sender, RoutedEventArgs e)
        {
            if (aRadio.IsOn)
            {
                aRadio.Channel = 1;
                LabelChannel.Content = aRadio.Play();
            }
            else
            {
                Channel1.IsChecked = false;
            }
        }

        private void Channel2_Checked(object sender, RoutedEventArgs e)
        {
            if (aRadio.IsOn)
            {
                aRadio.Channel = 2;
                LabelChannel.Content = aRadio.Play();
            }
            else
            {
                Channel2.IsChecked = false;
            }
        }

        private void Channel3_Checked(object sender, RoutedEventArgs e)
        {
            if (aRadio.IsOn)
            {
                aRadio.Channel = 3;
                LabelChannel.Content = aRadio.Play();
            }
            else
            {
                Channel3.IsChecked = false;
            }
        }

        private void Channel4_Checked(object sender, RoutedEventArgs e)
        {
            if (aRadio.IsOn)
            {
                aRadio.Channel = 4;
                LabelChannel.Content = aRadio.Play();
            }
            else
            {
                Channel4.IsChecked = false;
            }
        }

        private void TurnOn_Checked(object sender, RoutedEventArgs e)
        {
            aRadio.TurnOn();
            //Channel1.IsChecked = true;
            LabelChannel.Content = aRadio.Play();
        }

        private void TurnOff_Checked(object sender, RoutedEventArgs e)
        {
            aRadio.TurnOff();
            LabelChannel.Content = aRadio.Play();
            //Channel1.IsChecked = false;
            //Channel2.IsChecked = false;
            //Channel3.IsChecked = false;
            //Channel4.IsChecked = false;
        }


    }
}
