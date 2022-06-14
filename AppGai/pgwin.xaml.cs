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
    }
}
