using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
using teste.Commands;
using teste.Views;

namespace teste.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private readonly NavigationService _navigationService;

        private string _name;
        private string _email;
        private string _city;
        private string _region;
        private string _postalCode;
        private string _country;
        private string _phone;
        public string Error =>  null;

        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        [Required(ErrorMessage ="E-mail é obrigatório")]
        [EmailAddress(ErrorMessage ="E-mail inválido")]
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        [Required(ErrorMessage = "Cidade é obrigatória")]
        public string City
        {
            get => _city;
            set
            {
                _city = value;
                OnPropertyChanged(nameof(City));
            }
        }

        [Required(ErrorMessage ="O estado é obrigatório")]
        public string Region
        {
            get => _region;
            set
            {
                _region = value;
                OnPropertyChanged(nameof(Region));
            }
        }

        [Required(ErrorMessage = "O CEP é obrigatório")]
        public string PostalCode
        {
            get => _postalCode;
            set
            {
                _postalCode = value;
                OnPropertyChanged(nameof(PostalCode));
            }
        }

        [Required(ErrorMessage = "O país é obrigatório")]

        public string Country
        {
            get => _country;
            set
            {
                _country = value;
                OnPropertyChanged(nameof(Country));
            }
        }

        [Required(ErrorMessage = "O telefone é obrigatório")]

        public string Phone
        {
            get => _phone;
            set
            {
                _phone = value;
                OnPropertyChanged(nameof(Phone));    
            }
        }

        public ICommand SubmitCommand { get; }

        public UserViewModel(NavigationService navigationService)
        {
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            SubmitCommand = new RelayCommand(ExecuteSubmit);
        }

        

        //public UserViewModel()
        //{
        //    SubmitCommand = new RelayCommand(ExecuteSubmit);
        //}


        public string this[string columnName]
        {
            get
            {
                var validationContext = new ValidationContext(this) { MemberName = columnName };
                var results = new List<ValidationResult>();

                var property = GetType().GetProperty(columnName);
                if (property != null && property.GetIndexParameters().Length == 0)
                {
                    var value = property.GetValue(this); 
                    Validator.TryValidateProperty(value, validationContext, results);
                }

                return results.FirstOrDefault()?.ErrorMessage;
            }
        }

        //private void ExecuteSubmit(object parameter)

        //{
        //    var hasErrors = false;
        //    var errors = new List<string>();

        //    foreach (var property in typeof(UserViewModel).GetProperties())
        //    {
        //        var error = this[property.Name];
        //        if (!string.IsNullOrEmpty(error))
        //        {
        //            hasErrors = true;
        //            errors.Add(error);
        //        }


        //        if (hasErrors)
        //        {
        //            System.Windows.MessageBox.Show(string.Join("\n", errors));
        //            return;
        //        }

        //    }


        //    System.Windows.MessageBox.Show($"Nome: {Name}\nE-mail: {Email}\nCidade: {City}\nEstado: {Region}\nCEP: {PostalCode}\nPaís: {Country}\nTelefone: {Phone}");
        //}

        // Construtor
    
        private void ExecuteSubmit(object parameter)
        {
            var hasErrors = false;
            var errors = new List<string>();

            foreach (var property in typeof(UserViewModel).GetProperties())
            {
                var error = this[property.Name];
                if (!string.IsNullOrEmpty(error))
                {
                    hasErrors = true;
                    errors.Add(error);
                }
            }

            if (hasErrors)
            {
                System.Windows.MessageBox.Show(string.Join("\n", errors));
                return;
            }

            // Concatenar os dados em uma string
            var userData = $"Nome: {Name}\nE-mail: {Email}\nCidade: {City}\nEstado: {Region}\nCEP: {PostalCode}\nPaís: {Country}\nTelefone: {Phone}";

            // Navegar para a nova página
            var dataDisplayPage = new DataDisplayPage(userData);
            //NavigationService.Navigate(dataDisplayPage);
            if (_navigationService != null)
            {
                _navigationService.Navigate(dataDisplayPage);
                
            }
            else
            {
                System.Windows.MessageBox.Show("Navegação falhou: NavigationService não está disponível.");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
