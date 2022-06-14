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
        GaiDBEntities context;
        public CarPage()
        {
            InitializeComponent();
            context = new GaiDBEntities();
            cartable.ItemsSource = context.Car.ToList();            
        }

        public void RefreshData()
        {
            var list = context.Car.ToList();
            if (markbox.SelectedIndex > 0)
            {
                Mark pos = markbox.SelectedItem as Mark;
                list = list.Where(x => x.Mark1 == pos).ToList();
            }

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
    }
}
