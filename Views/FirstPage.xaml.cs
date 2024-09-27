﻿using System;
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
using teste.Repositories;
using teste.ViewModels;

namespace teste.Views
{
    /// <summary>
    /// Interação lógica para FirstPage.xam
    /// </summary>
    public partial class FirstPage : Page
    {
        public FirstPage()
        {
            InitializeComponent();
            Loaded += FirstPage_Loaded;
        }

        private void FirstPage_Loaded(object sender, RoutedEventArgs e)
        {
            var userRepository = new UserRepository();
            DataContext = new UserViewModel(NavigationService,userRepository);
        }
    }
}
