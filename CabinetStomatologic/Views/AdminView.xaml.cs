﻿using CabinetStomatologic.ViewModels;
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

namespace CabinetStomatologic.Views
{
    /// <summary>
    /// Interaction logic for AdminView.xaml
    /// </summary>
    public partial class AdminView : UserControl
    {
        public AdminView()
        {
            InitializeComponent();
            DataContext = new PrivilegesViewModel();
        }

        private void PrivilegesBtn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new PrivilegesViewModel();
        }

        private void InterventiiBtn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new InterventionsViewModel();
        }

        private void MediciBtn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new MediciViewModel();
        }

        private void AddMedicBtn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new AddMedicViewModel();
        }
    }
}
