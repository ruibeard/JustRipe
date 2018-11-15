using JustRipe.Models;
using System.Windows;

namespace JustRipe.ViewModels
{
    class DashBoardViewModel : ObservableObject, IBaseViewModel
    {

        public RelayCommand AddCropCommand { get; set; }


        public DashBoardViewModel()
        {
            PageName = "Dashboard";
        }
        private string pageName;

        public string PageName
        {
            get { return pageName; }
            set { pageName = value; }
        }

        void AddCrop(object parameter)
        {
            MessageBox.Show("add crop");

        }
    }

}
