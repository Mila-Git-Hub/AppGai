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
    /// Логика взаимодействия для HistoryCarPage.xaml
    /// </summary>
    public partial class HistoryCarPage : Page
    {
        GaiDB5Entities context;
        public HistoryCarPage(GaiDB5Entities context, Car car)
        {
            InitializeComponent();
            this.context = context;
            historyTable.ItemsSource = context.Car.ToList().Where(x => x.StateNumber == car.StateNumber).ToList();
        }
    }
}
