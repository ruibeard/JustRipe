using JustRipe.Data;
using JustRipe.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace JustRipe.ViewModels
{
    public class LoginViewModel : ObservableObject, IBaseViewModel
    {

        #region Fields

        private string _username;
        private string _password;
        private string _pageName;
        private Brush _color;
        private string _MessageText;

        #endregion

        #region Proprietys

        public Action CloseAction { get; set; }

        public string Username
        {
            get { return _username; }
            set
            {

                if (value != _username)
                {
                    _username = value;
                    OnPropertyChanged("Username");
                }
            }
        }

        public string Password
        {
            get { return _password; }
            //TODO: change this to private set
            // this is to auto fill the password
            set
            {
                if (value != _password)
                {
                    _password = value;
                    OnPropertyChanged("Password");
                }
            }
        }

        public string PageName
        {
            get { return _pageName; }
            set { _pageName = value; }
        }

        public Brush Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public string MessageText
        {
            get { return _MessageText; }
            set
            {
                if (_MessageText != value)
                {
                    _MessageText = value;
                    OnPropertyChanged("MessageText");
                }
            }
        }

        public RelayCommand LoginCommand { get; set; }

        public RelayCommand AddCropCommand { get; set; }
        #endregion

        #region Constructors

        public LoginViewModel()
        {
            _color = Brushes.Red;
            PageName = "login";
            LoginCommand = new RelayCommand(CheckCredentials);
        }
        #endregion


        private void CheckCredentials(object parameter)
        {
            var passwordBox = (PasswordBox)parameter;
            _password = passwordBox.Password;

            //User newUser = ;
            var count = UserRepository.CheckUserCredentials(
                new User
                {
                    Username = _username,
                    Password = _password
                });

            if (count < 1)
            {
                MessageBox.Show("Incorrect Credentials");
            }

            if (count == 1)
            {

                var mainView = new Views.MainView();
                var mainVM = new MainViewModel();

                mainView.DataContext = mainVM;
                mainView.Show();

                CloseAction();
            }
            if (count > 1)
            {
                MessageBox.Show("Duplicate user");
            }

        }

    }
}
