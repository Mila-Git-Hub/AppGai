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
    /// Логика взаимодействия для CarPage.xaml
    /// </summary>
    public partial class CarPage : Page
    {
        GaiDB5Entities context;
        public CarPage()
        {
            InitializeComponent();
            context = new GaiDB5Entities();
            cartable.ItemsSource = context.Car.ToList();
            var markList = context.Mark.ToList();
            markList.Insert(0, new Mark() { nameMark = "Все", idMark = 0});
            markbox.ItemsSource = markList;
        }

        public void RefreshData()
        {
            var list = context.Car.ToList();
            if (markbox.SelectedIndex > 0)
            {
                Mark pos = markbox.SelectedItem as Mark;
                list = list.Where(x => x.Mark1 == pos).ToList();
            }

            list = list.Where(x => x.StateNumber.ToLower().Contains(numbox.Text.ToLower())).ToList();

            if (string.IsNullOrWhiteSpace(numbox.Text))
            {
                list = list.Where(x => x.StateNumber.ToLower().Contains(numbox.Text.ToLower())).ToList();
            }
            cartable.ItemsSource = list;
        }

        private void ChangeMark(object sender, SelectionChangedEventArgs e)
        {
            RefreshData();
        }

        private void ChengeNum(object sender, TextChangedEventArgs e)
        {
            RefreshData();
        }

        private void AddCar(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddCars(context));
        }

        private void EditCar(object sender, RoutedEventArgs e)
        {
            Car car = cartable.SelectedItem as Car;
            NavigationService.Navigate(new AddCars(context, car));
        }

        private void DeleteCar(object sender, RoutedEventArgs e)
        {
            MessageBoxResult res = MessageBox.Show("Вы уверены, что хотите удалить автомобиль?", "Подтверждение", MessageBoxButton.YesNo);
            if (res == MessageBoxResult.Yes)
            {
                try
                {
                    Car car = cartable.SelectedItem as Car;
                    context.Car.Remove(car);
                    context.SaveChanges();
                    NavigationService.Navigate(new CarPage());
                }
                catch
                {
                    MessageBox.Show("Ошибка, удалите всех зарегистрированных водителей автомобиля!");
                }
            }
        }

        private void History(object sender, RoutedEventArgs e)
        {
            Car car = cartable.SelectedItem as Car;
            NavigationService.Navigate(new HistoryCarPage(context, car));
        }
    }
}
