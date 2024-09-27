using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using System.Windows.Navigation;
using teste.Commands;
using teste.Models;
using teste.Repositories;
using teste.Views;

namespace teste.ViewModels
{
    public class UserViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private readonly NavigationService _navigationService;
        private readonly UserRepository _userRepository;

        // Propriedades
        public ICommand SubmitCommand { get; }
        public ICommand RemoveUserCommand { get; }
        public ICommand NavigateToHomeCommand { get; }
        public ObservableCollection<User> Users => _userRepository.GetUsers();


        // Dados do Usuário
        private string _name;
        private string _email;
        private string _city;
        private string _region;
        private string _postalCode;
        private string _country;
        private string _phone;
        private int _id;

        // Validações
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

        [Required(ErrorMessage = "E-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
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

        [Required(ErrorMessage = "O estado é obrigatório")]
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

        // Propriedade para usuário selecionado
        private User _selectedUser;
        public User SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }

        public string Error => null;

        // Construtor
        public UserViewModel(NavigationService navigationService, UserRepository userRepository)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
            
            SubmitCommand = new RelayCommand(ExecuteSubmit);
            RemoveUserCommand = new RelayCommand(ExecuteRemoveUser);
            NavigateToHomeCommand = new RelayCommand(ExecuteNavigateToHome);
        }

        //Método para voltar para pagina inicial

        public void ExecuteNavigateToHome(object parameter)
        {
            _navigationService.GoBack();
        }

      
        //Debug exibir lista
        public void DisplayUsersInConsole()
        {
            Debug.WriteLine("Lista de Usuários:");
            foreach (var user in Users)
            {
                Debug.WriteLine($"Nome: {user.Name}, E-mail: {user.Email}, Cidade: {user.City}, Região: {user.Region}, CEP: {user.PostalCode}, País: {user.Country}, Telefone: {user.Phone}");
            }
        }

        //Método para remover usuário

        private void ExecuteRemoveUser(object parameter)
        {
            if (SelectedUser != null)
            {
                _userRepository.RemoveUser(SelectedUser);
                SelectedUser = null;
                OnPropertyChanged(nameof(Users));
            }
            DisplayUsersInConsole();
        }


        // Validação de propriedades
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

        // Método para enviar dados
        private void ExecuteSubmit(object parameter)
        {
            var hasErrors = false;
            var errors = new List<string>();

            if (_userRepository.UserExists(Name))
            {
                errors.Add("Já existe um usuário com o nome na lista");
                hasErrors = true;
            }

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

            var userData = new User()
            {
                Name = this.Name,
                Email = this.Email,
                City = this.City,
                Region = this.Region,
                PostalCode = this.PostalCode,
                Country = this.Country,
                Phone = this.Phone,
            };

            _userRepository.AddUser(userData);

            var dataDisplayPage = new DataDisplayPage(this);
            if (_navigationService != null)
            {
                _navigationService.Navigate(dataDisplayPage);
            }
            else
            {
                System.Windows.MessageBox.Show("Navegação falhou: NavigationService não está disponível.");
            }
        }

        // Evento de alteração de propriedade
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
