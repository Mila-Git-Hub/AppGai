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
    /// Логика взаимодействия для WinOsn.xaml
    /// </summary>
    public partial class WinOsn : Page
    {
        GaiDB5Entities context;
        public WinOsn()
        {
            InitializeComponent();
            context = new GaiDB5Entities();
        }

        int count = 0;

        private void EnterClicking(object sender, RoutedEventArgs e)
        {
            try
            {
                int numDriverDocument = Convert.ToInt32(login.Text);
                int pass = Convert.ToInt32(password.Text);


                Driver driver = context.Driver.ToList().Find(x => x.numDriverDocument == numDriverDocument);
                if (driver == null)
                {
                    MessageBox.Show("Водителя с таким номером не существует!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    count += 1;
                }
                else
                {
                    if (driver.password.Equals(pass))
                    {
                        MessageBox.Show("Успешная авторизация!", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                        myFrameDriv.Navigate(new pgwin());
                    }
                    else
                    {
                        MessageBox.Show("Пароли не совпадают!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                        count += 1;
                    }
                }
                if (count == 3)
                {
                    enter.IsEnabled = false;
                    login.IsEnabled = false;
                    password.IsEnabled = false;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Не введен пароль или логин!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }        
        }
    }
}
