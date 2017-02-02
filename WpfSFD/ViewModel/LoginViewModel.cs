using Classes;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfSFD.Views.Pages;

namespace WpfSFD.ViewModel
{
    public class LoginViewModel
    {
        private Login login;

        public LoginViewModel()
        {
            login = new Login();
            login.DataContext = this;
            Application.Current.Windows.OfType<Window>().FirstOrDefault().Content = this.login;
            login.LoginBtn.Click += LoginBtn_OnClick;
        }

        private void LoginBtn_OnClick(object sender, RoutedEventArgs e)
        {
            string login = this.login.login.Text;
            string password = this.login.password.Password;

            UserManager userManager = new UserManager();
            User user = userManager.GetByLogin(login, password);

            if (user.Id != 0)
            {

                new DataViewModel();
            }else
            {
                MessageBox.Show("t'as pas de compte batard ou tu t'es trompé enculé");
            }
        }
    }
}
