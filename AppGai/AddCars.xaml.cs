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
    /// Логика взаимодействия для AddCars.xaml
    /// </summary>
    public partial class AddCars : Page
    {
        GaiDB5Entities context;
        public AddCars(GaiDB5Entities cont)
        {
            InitializeComponent();
            context = cont;
            flag = true;
        }

        bool flag;

        private void SaveCar(object sender, RoutedEventArgs e)
        {
            if (flag == true)
            {

                Car car = new Car()
                {
                    StateNumber = StateNumberbox.Text,
                    mark = Convert.ToInt32(markbox.Text),
                    model = modelbox.Text,
                    color = colorbox.Text,
                    madeYear = Convert.ToInt32(madeYearbox.Text),
                    dateOfRegistration = Convert.ToDateTime(dateOfRegistrationbox.Text)
                };
                context.Car.Add(car);
                context.SaveChanges();
                NavigationService.Navigate(new CarPage());
            }
            else
            {
                context.Car.Find(carmin.StateNumber).mark = Convert.ToInt32(markbox.Text);
                context.Car.Find(carmin.StateNumber).model = modelbox.Text;
                context.Car.Find(carmin.StateNumber).color = colorbox.Text;
                context.Car.Find(carmin.StateNumber).madeYear = Convert.ToInt32(madeYearbox.Text);
                context.Car.Find(carmin.StateNumber).dateOfRegistration = Convert.ToDateTime(dateOfRegistrationbox.Text);
                context.SaveChanges();
                NavigationService.Navigate(new CarPage());
            }
        }

        Car carmin;

        public AddCars(GaiDB5Entities cont, Car car) //конструктор редактирования
        {
            InitializeComponent();
            context = cont;
            carmin = car;
            StateNumberbox.Text = car.StateNumber.ToString();
            markbox.Text = car.mark.ToString();
            modelbox.Text = car.model.ToString();
            colorbox.Text = car.color.ToString();
            madeYearbox.Text = car.madeYear.ToString();
            dateOfRegistrationbox.Text = car.dateOfRegistration.ToString();
            flag = false;
        }
    }
}
