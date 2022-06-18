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
    /// Логика взаимодействия для AddWorker.xaml
    /// </summary>
    public partial class AddWorker : Page
    {
        GaiDBEntities context;
        public AddWorker(GaiDBEntities cont)
        {
            InitializeComponent();
            context = cont;
            flag = true;
        }

        bool flag;

        private void SaveDriver(object sender, RoutedEventArgs e)
        {
            if (flag == true)
            {

                Driver driver = new Driver()
                {
                    numDriverDocument = Convert.ToInt32(idbox.Text),
                    name = fiobox.Text,
                    adres = adresbox.Text,
                    phone = Convert.ToInt32(phonebox.Text)
                };
                context.Driver.Add(driver);
                context.SaveChanges();
                NavigationService.Navigate(new DriverPage());
            }
            else
            {
                context.Driver.Find(driv.numDriverDocument).name = fiobox.Text;
                context.Driver.Find(driv.numDriverDocument).adres = adresbox.Text;
                context.Driver.Find(driv.numDriverDocument).phone = Convert.ToDecimal(phonebox.Text);
                context.SaveChanges();
                NavigationService.Navigate(new DriverPage());
            }
        }

        Driver driv;

        public AddWorker(GaiDBEntities cont, Driver driver) //конструктор редактирования
        {
            InitializeComponent();
            context = cont;
            driv = driver;
            idbox.Text = driver.numDriverDocument.ToString();
            fiobox.Text = driver.name.ToString();
            adresbox.Text = driver.adres.ToString();
            phonebox.Text = driver.phone.ToString();
            flag = false;
        }
    }
}
