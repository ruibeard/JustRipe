using JustRipe.Data;
using JustRipe.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace JustRipe.ViewModels
{
    public class LoginViewModel : ObservableObject, IBaseViewModel
    {
        #region Properties

        private string username;

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string pageName;

        public string PageName
        {
            get { return pageName; }
            set { pageName = value; }
        }

        #endregion



        #region Contructors

        public LoginViewModel()
        {

            PageName = "Login Page";
            LoginCommand = new RelayCommand(PerformLogin);
        }

        #endregion



        #region Methods

        private void PerformLogin(object parameter)
        {
            //TODO
            // Anyone in the team is welcome to implement it
            //this Violates de mvvm pattern as the view knows about the passwordbox
            //Check this link to improve it 
            //https://stackoverflow.com/a/25001115


            //Get the password string as parameter from the ICommand(click) on the button Login and make it as PasswordBox
            var passwordBox = parameter as PasswordBox;

            // Checks if password is empty, if so return nothing 
            if (string.IsNullOrWhiteSpace(passwordBox.Password))
                return;

            // Checks if username is empty, if so return nothing 
            if (string.IsNullOrWhiteSpace(Username))
                return;


            SqliteDataAccess.CheckUserCredentials(Username, passwordBox.Password);

            //Compare creadentials passed from user agains the Users table in database


            //IF credentials match open MainView


            //Else give error to user



            MessageBox.Show(Username);
            MessageBox.Show(passwordBox.Password);
        }

        public RelayCommand LoginCommand { get; set; }

        #endregion

    }

}
