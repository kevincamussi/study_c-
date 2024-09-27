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
using teste.Models;
using teste.ViewModels;

namespace teste.Views
{
    /// <summary>
    /// Interação lógica para DataDisplayPage.xam
    /// </summary>
    public partial class DataDisplayPage : Page
    {
        public DataDisplayPage(UserViewModel userViewModel)
        {
            InitializeComponent();
            DataContext = userViewModel; 
        }
    }
}
