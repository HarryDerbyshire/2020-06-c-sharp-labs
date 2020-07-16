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
using Calculator;

namespace CalculatorInterface
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

        static int FirstNum;
        static int SecondNum;
        static string Operator = "";

        public void Calculations(int Num1, int Num2, string Operator)
        {
            if (Operator == "")
            {
                FirstNum = Num1;
            }
            else if (Operator == "+")
            {
                LabelDisplay.Content = "";
                LabelDisplay.Content = Operations.Addition(Num1, Num2);
            }
            else if (Operator == "-")
            {
                LabelDisplay.Content = "";
                LabelDisplay.Content = Operations.Subtraction(Num1, Num2);
            }
            else if (Operator == "/")
            {
                if (Num2 == 0)
                {
                    LabelDisplay.Content = "Divide Error";
                }
                else
                {
                    LabelDisplay.Content = "";
                    LabelDisplay.Content = Operations.Division(Num1, Num2);
                }
            }
            else if (Operator == "*")
            {
                LabelDisplay.Content = "";
                LabelDisplay.Content =Operations.Multiplication(Num1, Num2);
            }
            else if (Operator == "%")
            {

                if (Num2 == 0)
                {
                    LabelDisplay.Content = "Divide Error";
                }
                else
                {
                    LabelDisplay.Content = "";
                    LabelDisplay.Content = Operations.Modulus(Num1, Num2);
                }

            }
        }

        private void ButtonAddition_Click(object sender, RoutedEventArgs e)
        {
            Operator = "+";
            FirstNum = Convert.ToInt32(LabelDisplay.Content);
            LabelDisplay.Content = "";

        }
        private void ButtonEquals_Click(object sender, RoutedEventArgs e)
        {
            SecondNum = Convert.ToInt32(LabelDisplay.Content);
            Calculations(FirstNum, SecondNum, Operator);
        }

        private void Button01_Click(object sender, RoutedEventArgs e)
        {
            LabelDisplay.Content += "1";
        }

        private void Button02_Click(object sender, RoutedEventArgs e)
        {
            LabelDisplay.Content += "2";
        }

        private void Button03_Click(object sender, RoutedEventArgs e)
        {
            LabelDisplay.Content += "3";
        }

        private void Button04_Click(object sender, RoutedEventArgs e)
        {
            LabelDisplay.Content += "4";
        }

        private void Button05_Click(object sender, RoutedEventArgs e)
        {
            LabelDisplay.Content += "5";
        }

        private void Button06_Click(object sender, RoutedEventArgs e)
        {
            LabelDisplay.Content += "6";
        }

        private void Button07_Click(object sender, RoutedEventArgs e)
        {
            LabelDisplay.Content += "7";
        }

        private void Button08_Click(object sender, RoutedEventArgs e)
        {
            LabelDisplay.Content += "8";
        }

        private void Button09_Click(object sender, RoutedEventArgs e)
        {
            LabelDisplay.Content += "9";
        }

        private void Button00_Click(object sender, RoutedEventArgs e)
        {
            LabelDisplay.Content += "0";
        }

        private void ButtonSubtraction_Click(object sender, RoutedEventArgs e)
        {
            Operator = "-";
            FirstNum = Convert.ToInt32(LabelDisplay.Content);
            LabelDisplay.Content = "";
        }

        private void ButtonMultiplication_Click(object sender, RoutedEventArgs e)
        {
            Operator = "*";
            FirstNum = Convert.ToInt32(LabelDisplay.Content);
            LabelDisplay.Content = "";
        }

        private void ButtonDivision_Click(object sender, RoutedEventArgs e)
        {
            Operator = "/";
            FirstNum = Convert.ToInt32(LabelDisplay.Content);
            LabelDisplay.Content = "";
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            LabelDisplay.Content = "";
            Operator = "";
            FirstNum = 0;
            SecondNum = 0;
        }

        private void ButtonModulus_Click(object sender, RoutedEventArgs e)
        {
            Operator = "%";
            FirstNum = Convert.ToInt32(LabelDisplay.Content);
            LabelDisplay.Content = "";
        }
    }
}
