using System;
using System.Collections.Generic;
using System.IO;
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

namespace AppGai
{
    /// <summary>
    /// Логика взаимодействия для pgwin.xaml
    /// </summary>
    public partial class pgwin : Page
    {
        public pgwin()
        {
            InitializeComponent();             
            myFrame.Navigate(new ViolationPage());
        }

        private void ShowViolations(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(new ViolationPage());
        }

        private void ShowDrivers(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(new DriverPage());
        }

        private void ShowCars(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(new CarPage());
        }

        public void DownloadPictures()
        {
            GaiDB5Entities context = new GaiDB5Entities();

            List<Violation> violations = context.Violation.ToList();
            
            foreach (var item in violations)
            {
                item.image = File.ReadAllBytes(@"C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\PicturesGai\" + item.id + ".jpg");
            }

            context.SaveChanges();

        }

        private void ShowListViolation(object sender, RoutedEventArgs e)
        {
            myFrame.Navigate(new ListViolationPage());
        }
    }
}
