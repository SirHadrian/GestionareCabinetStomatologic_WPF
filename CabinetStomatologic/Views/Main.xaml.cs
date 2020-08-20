using CabinetStomatologic.ViewModels;
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
using System.Windows.Shapes;

namespace CabinetStomatologic.Views
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
            DataContext = new HomeViewModel();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new HomeViewModel();
        }

        private void AdminBtn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new AdminViewModel();
        }

        private void MedicBtn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new MedicViewModel();
        }
    }
}
