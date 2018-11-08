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
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            _Main MainWindow = new _Main();
            MainWindow.Show();
            this.Close();
        }
    }
}
