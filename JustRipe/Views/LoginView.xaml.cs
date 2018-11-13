using JustRipe.ViewModels;
using System;
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
            LoginViewModel loginVM = new LoginViewModel();
            DataContext = loginVM;

            if (loginVM.CloseAction == null)
                loginVM.CloseAction = new Action(this.Close);
        }

        private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();

        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
