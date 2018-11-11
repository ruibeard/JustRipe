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

    }
}
