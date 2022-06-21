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
    /// Логика взаимодействия для AddViolations.xaml
    /// </summary>
    public partial class AddViolations : Page
    {
        GaiDB4Entities context;
        public AddViolations(GaiDB4Entities cont)
        {
            InitializeComponent();
            context = cont;
            flag = true;
        }

        bool flag;

        private void SaveViolation(object sender, RoutedEventArgs e)
        {
            if (flag == true)
            {
                Violation violation = new Violation()
                {
                    id = Convert.ToInt32(idbox.Text),
                    title = titlebox.Text,
                    penaltyRange = penaltybox.Text,
                    deprivationLicense = deprivationLicensebox.Text
                };
                context.Violation.Add(violation);
                context.SaveChanges();
                NavigationService.Navigate(new ViolationPage());
            }
            else
            {
                context.Violation.Find(vil.id).title = titlebox.Text;
                context.Violation.Find(vil.id).penaltyRange = penaltybox.Text;
                context.Violation.Find(vil.id).deprivationLicense = deprivationLicensebox.Text;
                context.SaveChanges();
                NavigationService.Navigate(new ViolationPage());
            }
        }
        Violation vil;

        public AddViolations(GaiDB4Entities cont, Violation violation) //конструктор редактирования
        {
            InitializeComponent();
            context = cont;
            vil = violation;
            titlebox.Text = violation.title.ToString();
            penaltybox.Text = violation.penaltyRange.ToString();
            deprivationLicensebox.Text = violation.deprivationLicense.ToString();
            flag = false;
        }
    }
}
