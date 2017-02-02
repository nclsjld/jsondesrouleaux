using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfSFD.ViewModel;
using WpfSFD.Views.Pages;

namespace WpfSFD
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {

        public App()
        {
            Window main = new Window();
            main.Content = new Login();
            main.Loaded += Main_Loaded;
            main.Show();

        }

        private void Main_Loaded(object sender, RoutedEventArgs e)
        {
            new LoginViewModel();
        }
    }
}
