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
            Main MainWindow = new Main();
            MainWindow.Show();
            this.Close();
        }
    }
}
