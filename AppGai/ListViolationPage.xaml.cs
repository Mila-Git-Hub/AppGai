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
    /// Логика взаимодействия для ListViolationPage.xaml
    /// </summary>
    public partial class ListViolationPage : Page
    {
        GaiDB5Entities context;
        public ListViolationPage()
        {
            InitializeComponent();
            context = new GaiDB5Entities();
            violationsListView.ItemsSource = context.Violation.ToList();            
        }

        private void ClickToListItem(object sender, MouseButtonEventArgs e)
        {
            Violation violation = (sender as Grid).DataContext as Violation;
            NavigationService.Navigate(new InformationViolationPage(context, violation));
        }
    }
}
