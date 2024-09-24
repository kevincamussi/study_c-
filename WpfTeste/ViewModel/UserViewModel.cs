using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using WpfTeste.Model;

namespace WpfTeste.ViewModel
{
    public class UserViewModel: INotifyPropertyChanged
    {
        private User _user;

        public UserViewModel()
        {
            _user = new User { Name = "", Age = 0 };
        }

        public string Name
        { 
            get { return _user.Name; } 
            set {
                _user.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public int Age
        {
            get { return _user.Age; }
            set
            {
                _user.Age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
