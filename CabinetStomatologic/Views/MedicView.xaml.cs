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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CabinetStomatologic.Views
{
    /// <summary>
    /// Interaction logic for MedicView.xaml
    /// </summary>
    public partial class MedicView : UserControl
    {
        public MedicView()
        {
            InitializeComponent();
            DataContext = new PacientiViewModel();
        }

        private void AddPacientBtn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new AddPacientViewModel();
        }

        private void PacientiBtn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new PacientiViewModel();
        }

        private void ProgramariBtn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ProgramariViewModel();
        }

        private void AddProgramareBtn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new AddProgramareViewModel();
        }
    }
}
