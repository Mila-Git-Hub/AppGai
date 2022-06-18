﻿using System;
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
    /// Логика взаимодействия для ViolationPage.xaml
    /// </summary>
    public partial class ViolationPage : Page
    {
        GaiDBEntities context;
        public ViolationPage()
        {
            InitializeComponent();
            context = new GaiDBEntities();
            violationTable.ItemsSource = context.Violation.ToList();
        }

        public void RefreshData()
        {
            var list = context.Violation.ToList();

            list = list.Where(x => x.title.ToLower().Contains(naimenbox.Text.ToLower())).ToList();

            if (string.IsNullOrWhiteSpace(naimenbox.Text))
            {
                list = list.Where(x => x.title.ToLower().Contains(naimenbox.Text.ToLower())).ToList();
            }
            violationTable.ItemsSource = list;
        }

        private void ChengeNaimen(object sender, TextChangedEventArgs e)
        {
            RefreshData();
        }
    }
}
