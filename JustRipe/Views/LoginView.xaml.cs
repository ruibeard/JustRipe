using JustRipe.ViewModels;
using System.Windows;

namespace JustRipe.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }

        //private void LoginButton_Click(object sender, RoutedEventArgs e)
        //{
        //    ApplicationView MainWindow = new ApplicationView();
        //    MainWindow.Show();
        //    this.Close();
        //}
    }
}
