using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using teste.Commands;

namespace teste.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
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

        public UserViewModel()
        {
            SubmitCommand = new RelayCommand(ExecuteSubmit);
        }


        public string this[string columnName]
        {
            get
            {
                var validationContext = new ValidationContext(this) { MemberName = columnName };
                var results = new List<ValidationResult>();

                // Obter a propriedade pelo nome e verificar se ela é acessível
                var property = GetType().GetProperty(columnName);
                if (property != null && property.GetIndexParameters().Length == 0)
                {
                    var value = property.GetValue(this); // Obter o valor da propriedade
                    Validator.TryValidateProperty(value, validationContext, results);
                }

                return results.FirstOrDefault()?.ErrorMessage;
            }
        }

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


                if (hasErrors)
                {
                    System.Windows.MessageBox.Show(string.Join("\n", errors));
                    return;
                }

            }


            System.Windows.MessageBox.Show($"Nome: {Name}\nE-mail: {Email}\nCidade: {City}\nEstado: {Region}\nCEP: {PostalCode}\nPaís: {Country}\nTelefone: {Phone}");
        }

        //private void ExecuteSubmit(object parameter)
        //{
        //    // Exibe apenas o nome
        //    if (!string.IsNullOrEmpty(Name))
        //    {
        //        System.Windows.MessageBox.Show($"Nome: {Name}");
        //    }
        //    else
        //    {
        //        System.Windows.MessageBox.Show("Nome é obrigatório!");
        //    }
        //}


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
