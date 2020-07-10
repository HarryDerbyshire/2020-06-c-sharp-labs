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
using System.IO;
using System.Diagnostics;
using System.Threading;
using Xceed.Words.NET;

namespace lab_12_big_button
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

        private void ButtonGO_Click(object sender, RoutedEventArgs e)
        {
            var stopwatch = new Stopwatch();

            string path = "C:\\github\\2020-06-c-sharp-labs\\labs\\lab_12_big_button\\bin\\Debug\\netcoreapp3.1\\test-folder";
            if (Directory.Exists(path)) Directory.Delete(path, true);
               
            Directory.CreateDirectory(path);

            stopwatch.Start();

            for (int i = 0; i < 1000; i ++)
            {
                using (StreamWriter sw = File.CreateText(path + "\\I am file number " + i + ".txt"))
                {
                    sw.WriteLine(DateTime.Now);

                }
            }

            stopwatch.Stop();
            ButtonGO.Content = stopwatch.ElapsedMilliseconds + "ms";

            var document = DocX.Create("FileCreatedStats.docx");
            document.InsertParagraph($"1000 files generated in {stopwatch.ElapsedMilliseconds}ms");
            document.InsertParagraph($"Report generated at {DateTime.Now}");
            document.Save();
        }
    }
}
