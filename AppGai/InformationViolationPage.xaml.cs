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
    /// Логика взаимодействия для InformationViolationPage.xaml
    /// </summary>
    public partial class InformationViolationPage : Page
    {
        GaiDB5Entities context;
        public InformationViolationPage(GaiDB5Entities context, Violation violation)
        {
            InitializeComponent();
            this.context = context;
            violationsTable.ItemsSource = context.Violation.ToList().Where(x => x.id == violation.id).ToList();
        } 
    }
}
