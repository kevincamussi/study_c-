using System.ComponentModel;
using System.Windows.Input;
using CalculadoraApp.Models;

namespace CalculadoraApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly CalculatorModel _calculatorModel;
        private string _display;
        private bool _isEqualExecuted;
        public string Display
        { 
            get { return _display; }
            set
            {
                _display = value;
                OnPropertyChanged(nameof(Display));
            }
        }

        public ICommand NumberCommand { get; }
        public ICommand OperatorCommand { get; }
        public ICommand ClearCommand { get; }
        public ICommand EqualsCommand { get; }

        public MainViewModel()
        {
            _calculatorModel = new CalculatorModel();
            NumberCommand = new RelayCommand<string>(OnNumberClicked);
            OperatorCommand = new RelayCommand<string>(OnOperatorClicked);
            ClearCommand = new RelayCommand(OnClearClicked);
            EqualsCommand = new RelayCommand(OnEqualsClicked);
            Display = "0";
        }

        private void OnNumberClicked(string number)
        {
            if (_calculatorModel.IsOperationPerformed || Display == "0" || _isEqualExecuted)
            {
                Display = number;
                _calculatorModel.IsOperationPerformed = false;
                _isEqualExecuted = false;
            }
            else
            {
                Display += number;
            }
        }


        private void OnOperatorClicked(string operation)
        {
            if (_calculatorModel.Result != 0)
            {
                OnEqualsClicked();
            }

            _calculatorModel.Operation = operation;
            _calculatorModel.Result = double.Parse(Display);
            _calculatorModel.IsOperationPerformed = true;
            _isEqualExecuted = false;
        }

        private void OnEqualsClicked()
        {
            switch (_calculatorModel.Operation)
            {
                case "+":
                    Display = (_calculatorModel.Result + double.Parse(Display)).ToString();
                    break;
                case "-":
                    Display = (_calculatorModel.Result - double.Parse(Display)).ToString();
                    break;
                case "*":
                    Display = (_calculatorModel.Result * double.Parse(Display)).ToString();
                    break;
                case "/":
                    Display = (_calculatorModel.Result / double.Parse(Display)).ToString();
                    break;
                default:
                    break;
            }

            _calculatorModel.Result = double.Parse(Display);
            _calculatorModel.Operation = string.Empty;
            _isEqualExecuted = true;
        }

        private void OnClearClicked()
        {
            Display = "0";
            _calculatorModel.Result = 0;
            _calculatorModel.Operation = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
