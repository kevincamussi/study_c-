using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTeste
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ShowData_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as ViewModel.UserViewModel;
            MessageBox.Show($"Name: {viewModel.Name}, Age: {viewModel.Age}");
        }
    }
}