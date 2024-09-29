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

namespace teste.Views
{
    /// <summary>
    /// Interação lógica para CustomButton.xam
    /// </summary>
    public partial class CustomButton : UserControl
    {
        public CustomButton()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ButtonContentProperty = DependencyProperty.Register("ButtonContent", typeof(string), typeof(CustomButton));

        public string ButtonContent
        {
            get { return (string)GetValue(ButtonContentProperty); }
            set { SetValue(ButtonContentProperty, value); }
        }

        public static readonly DependencyProperty ButtonCommandProperty = DependencyProperty.Register("ButtonCommand", typeof(ICommand), typeof(CustomButton));

        public ICommand ButtonCommand
        {
            get { return (ICommand)GetValue(ButtonCommandProperty); }
            set { SetValue(ButtonCommandProperty, value); }
        }


        public static readonly DependencyProperty ButtonBackgroundProperty = DependencyProperty.Register("ButtonBackground", typeof(Brush), typeof(CustomButton));

        public Brush ButtonBackground
        {
            get { return (Brush)GetValue(ButtonBackgroundProperty); }
            set { SetValue(ButtonBackgroundProperty, value); }

        }

        public static readonly DependencyProperty HoverBackgroundProperty = DependencyProperty.Register("HoverBackground", typeof(Brush), typeof(CustomButton));

        public Brush HoverBackground
        {
            get { return (Brush)GetValue(HoverBackgroundProperty); }
            set { SetValue(HoverBackgroundProperty, value); }
        }


    }
}
