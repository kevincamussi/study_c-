using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfLogin.Views;

namespace WpfLogin.Commands
{
    public class LogarCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var telaPrincipal = new WinPrincipal();
            telaPrincipal.Show();
            Helper.Helpers.FecharTelaLogin();

            //string senha = (parameter as PasswordBox).Password;
            //MessageBox.Show(senha);
        }

    }
}


