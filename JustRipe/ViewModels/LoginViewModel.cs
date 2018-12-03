using JustRipe.Data.DTOs;
using JustRipe.Data.Repositories;
using JustRipe.Models;
using JustRipe.Utils;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace JustRipe.ViewModels
{
   public class LoginViewModel : ObservableObject
   {
      #region Fields
      /// <summary>
      /// fields used for encryption password
      /// </summary>
      public const String strPermutation = "neverstoplearning";
      public const Int32 bytePermutation1 = 0x19;
      public const Int32 bytePermutation2 = 0x59;
      public const Int32 bytePermutation3 = 0x17;
      public const Int32 bytePermutation4 = 0x41;

      private string _username;
      private string _password;
      private string _pageName;
      private string _MessageText;
      #endregion

      #region Properties
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

      #endregion

      #region Constructors

      public LoginViewModel()
      {
         PageName = "login";
         LoginCommand = new RelayCommand(CheckCredentials);
      }
      #endregion

      // encoding

      private UserRepository GetRepository()
      {
         return new UserRepository(new Repository<UserDTO>(), new Repository<RoleDTO>(), new Repository<UserRoleDTO>());
      }
      private void CheckCredentials(object parameter)
      {

         if (parameter == null)
            return;

         var passwordBox = (PasswordBox)parameter;
         _password = passwordBox.Password;

         var isUserCredentialsCorrect = GetRepository().CheckUserCredentials(_username, EncryptPassword.Encrypt(_password));

         if (isUserCredentialsCorrect != null && isUserCredentialsCorrect.GetEnumerator().MoveNext())
         {
            var returnedUser = isUserCredentialsCorrect.FirstOrDefault<User>();
            var mainView = new Views.MainView();
            var mainVM = new MainViewModel();

            MainViewModel.LoggedUserName = "Welcome, " + returnedUser.FirstName + " - " + returnedUser.Role;
            mainView.DataContext = mainVM;
            mainView.Show();
            CloseAction();
         }
         else
         {
            MessageBox.Show("Incorrect Credentials");
         }
      }
   }
}