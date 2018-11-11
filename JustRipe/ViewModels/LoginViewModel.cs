using JustRipe.Data;
using JustRipe.Models;
using System;
using System.Data.SQLite;
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
            private set
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
                    //OnPropertyChanged(MessageText);
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
            SQLiteDatabase db = new SQLiteDatabase();
            string query = string.Empty;
            string queryString = string.Empty;
            var passwordBox = (PasswordBox)parameter;
            _password = passwordBox.Password;

            try
            {
                db.OpenConnection();

                if (db.ConnectionState == false)
                {
                    MessageText = "ERROR: Cannot open Database connectiton.\n" + db.Status;
                }

                MessageText += db.Status + '\n';
                string num_rows = "-1";


                using (SQLiteCommand cmd = new SQLiteCommand(db.Connection))
                {
                    cmd.CommandText = "select count(*) from users where  username = @Username and  password = @Password ";
                    cmd.Parameters.AddWithValue("@Username", Username);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    num_rows = cmd.ExecuteScalar().ToString();
                }

                int count = Convert.ToInt32(num_rows);

                if (count < 1)
                {
                    MessageBox.Show("Incorrect Credentials");
                    Username = "";
                    Password = "";

                    MessageBox.Show(Username);
                }

                if (count == 1)
                {
                    MessageBox.Show("Correct Credentials");

                    var mainView = new Views.MainView();
                    var mainVM = new MainViewModel();

                    mainView.DataContext = mainVM;
                    mainView.ShowDialog();

                    CloseAction();
                }
                if (count > 1)
                {
                    MessageBox.Show("Duplicate user");
                    Username = "";
                    Password = "";
                }

            }
            catch (System.Exception exp)
            {
                MessageText += "\n\nAN ERROR OCURRED: " + exp.Message + "\n";
                MessageText += "\n\nAt line: \n";
                MessageText += "Query was: " + queryString + "\n";
            }
            finally
            {
                db.CloseConnection();
            }

        }

    }

}
