using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfLogin.Commands;

namespace WpfLogin.ViewModels
{
    public class LogarViewModel
    {
        public LogarCommand Logar{ get; set; }

        public LogarViewModel()
        {
            Logar = new LogarCommand();
        }
    }
}
