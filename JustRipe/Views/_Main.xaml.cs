using JustRipe.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace JustRipe.Views
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class _Main : Window
    {
        public _Main()
        {

            InitializeComponent();


            //this line prevents from window covers taskbar when maximized
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonMaxmize_Click(object sender, RoutedEventArgs e)
        {
            MaximizeWindow();
        }

        private void ButtonRestore_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Normal;
            ButtonMaxmize.Visibility = Visibility.Visible;
            ButtonRestore.Visibility = Visibility.Collapsed;

        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }

        private void MaximizeWindow()
        {
            SystemCommands.MaximizeWindow(this);
            ButtonMaxmize.Visibility = Visibility.Collapsed;
            ButtonRestore.Visibility = Visibility.Visible;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            switch (this.WindowState)
            {
                case WindowState.Maximized:
                    ButtonMaxmize.Visibility = Visibility.Collapsed;
                    ButtonMinimize.Visibility = Visibility.Visible;
                    break;

                case WindowState.Normal:
                    ButtonMaxmize.Visibility = Visibility.Visible;
                    ButtonRestore.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void ContentControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;

                ButtonMaxmize.Visibility = Visibility.Visible;
                ButtonRestore.Visibility = Visibility.Collapsed;
            }
            else
            {
                WindowState = WindowState.Maximized;
                ButtonMaxmize.Visibility = Visibility.Collapsed;
                ButtonRestore.Visibility = Visibility.Visible;
            }
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {

            var item = sender as ListViewItem;


            DataContext = new CropViewModel();
            MessageBox.Show(item.Name);


        }
    }
}
