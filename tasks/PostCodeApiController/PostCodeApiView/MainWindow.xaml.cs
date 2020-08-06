using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using PostCodeApiController;

namespace PostCodeApiView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Root currentAddress = new Root();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonFind_Click(object sender, RoutedEventArgs e)
        {
            Uri validateUrl = new Uri($"https://api.postcodes.io/postcodes/{TextBoxPostcode.Text}/validate");
            bool isValid = Program.ValidatePostcode(validateUrl);
            if (isValid == true)
            {
                if (TextBoxPostcode.Text != "" && TextBoxPostcode.Text != "Not a valid postcode")
                {
                    ButtonOpen.IsEnabled = true;
                    ButtonOpen.Visibility = Visibility.Visible;
                    currentAddress = Program.GetLocation(TextBoxPostcode.Text);
                    LabelConstituency.Content = currentAddress.result.parliamentary_constituency;
                    LabelCountry.Content = currentAddress.result.country;
                    LabelNhsRegion.Content = currentAddress.result.nhs_ha;
                    LabelDistrict.Content = currentAddress.result.admin_district;
                    LabelWard.Content = currentAddress.result.admin_ward;
                }

            }
            else
            {
                ButtonOpen.IsEnabled = false;
                ButtonOpen.Visibility = Visibility.Hidden;
                TextBoxPostcode.Text = "Not a valid postcode";
                LabelConstituency.Content = "";
                LabelCountry.Content = "";
                LabelNhsRegion.Content = "";
                LabelDistrict.Content = "";
                LabelWard.Content = "";
            }


            }

        private void ButtonOpen_Click(object sender, RoutedEventArgs e)
        {            
            Process.Start("explorer", $"https://www.google.com/maps/place/{TextBoxPostcode.Text}");
        }
    }
}
