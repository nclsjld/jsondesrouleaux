using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfSFD.Views.Pages;
using System.Windows;
using Database;

namespace WpfSFD.ViewModel
{
    public class UserCreationViewModel
    {
        #region attributs

        private UserCreation userCreation;
        private User user;
        #endregion

        public UserCreationViewModel() 
        {
            this.userCreation = new UserCreation();
            userCreation.DataContext = this;
            //user = new User();
            Application.Current.Windows.OfType<Window>().FirstOrDefault().Content = this.userCreation;
            userCreation.CreateUserBtn.Click += CreateUserBtn_OnClick;
        }

        private void CreateUserBtn_OnClick(object sender, RoutedEventArgs e)
        {
           
            User keen = new User();
            keen.Firstname = this.userCreation.firstname.Text ;
            keen.Lastname = this.userCreation.lastname.Text;
            keen.Login = keen.Firstname + keen.Lastname;
            keen.Password = this.userCreation.password.Text;
            //jason.Roles.Add(r1);
            keen.IdRole = 2;

            MessageBox.Show("Utilisateur créé");


            MySQLManager<User> managerUser = new MySQLManager<User>(DataConnectionResource.LOCALMYSQL);
            managerUser.Insert(keen);
        }
    }
}
