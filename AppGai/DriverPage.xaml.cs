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
    /// Логика взаимодействия для DriverPage.xaml
    /// </summary>
    public partial class DriverPage : Page
    {
        GaiDB5Entities context;
        public DriverPage()
        {
            InitializeComponent();
            context = new GaiDB5Entities();
            driverTable.ItemsSource = context.Driver.ToList();
        }

        private void AddDriver(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddWorker(context));
        }

        private void EditDriver(object sender, RoutedEventArgs e)
        {
            Driver driver = driverTable.SelectedItem as Driver;
            NavigationService.Navigate(new AddWorker(context, driver));
        }

        private void DeleteDriver(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Вы уверены, что хотите удалить водителя?", "Подтверждение", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                try
                {
                    Driver driver = driverTable.SelectedItem as Driver;                   
                    context.Driver.Remove(driver);
                    context.SaveChanges();
                    NavigationService.Navigate(new DriverPage());
                }
                catch
                {
                    MessageBox.Show("Ошибка, удалите все зарегистрированные машины водителя!");
                }
            }
        }

        public void RefreshData()
        {
            var list = context.Driver.ToList();

            list = list.Where(x => x.name.ToLower().Contains(docbox.Text.ToLower())).ToList();

            if (string.IsNullOrWhiteSpace(docbox.Text))
            {
                list = list.Where(x => x.name.ToLower().Contains(docbox.Text.ToLower())).ToList();
            }
            driverTable.ItemsSource = list;
        }

        private void ChengeDoc(object sender, TextChangedEventArgs e)
        {
            RefreshData();
        }
    }
}
