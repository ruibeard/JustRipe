using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace JustRipe
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); 
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
 

  
        /// <summary>
        /// Maximize Current Windows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonMaxmize_Click(object sender, RoutedEventArgs e)
        {
            SystemCommands.MaximizeWindow(this);
            ButtonMaxmize.Visibility = Visibility.Collapsed;
            ButtonMinimize.Visibility = Visibility.Visible ;
        }
        /// <summary>
        /// Minimize current Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);

            ButtonMaxmize.Visibility = Visibility.Visible;
            ButtonMinimize.Visibility = Visibility.Hidden;

        }
    }
}
