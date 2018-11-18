using JustRipe.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JustRipe.ViewModels
{
    class MainViewModel : ObservableObject, IBaseViewModel
    {
        /// <summary>
        /// Properties that we use in every menu button on the main view.
        /// </summary>
        public RelayCommand DashboardCommand { get; set; }
        public RelayCommand CropCommand { get; set; }
        public RelayCommand FertiliserCommand { get; set; }
        public RelayCommand CategoryCommand { get; set; }
        public RelayCommand HarvestCommand { get; set; }
        public RelayCommand ProductCommand { get; set; }
        public RelayCommand StockCommand { get; set; }
        public RelayCommand StorageCommand { get; set; }
        public RelayCommand UserCommand { get; set; }
        public RelayCommand VehicleCommand { get; set; }

        private object selectedViewModel;

        public object SelectedViewModel
        {
            get { return selectedViewModel; }
            set { selectedViewModel = value; OnPropertyChanged(nameof(SelectedViewModel)); }
        }


        public MainViewModel()
        {

            SelectedViewModel = new DashBoardViewModel();


            CropCommand = new RelayCommand(OpenCrop);
            FertiliserCommand = new RelayCommand(OpenFertiliser);
            CategoryCommand = new RelayCommand(OpenCategory);
            HarvestCommand = new RelayCommand(OpenHarvest);
            ProductCommand = new RelayCommand(OpenProduct);
            StockCommand = new RelayCommand(OpenStock);
            StorageCommand = new RelayCommand(OpenStorage);
            UserCommand = new RelayCommand(OpenUser);
            VehicleCommand = new RelayCommand(OpenVehicle);
        }

        private void OpenDashboard(object obj)
        {
            SelectedViewModel = new DashBoardViewModel();
        }
        private void OpenChild(object obj)
        {
            SelectedViewModel = new StockViewModel();


        }

        private void OpenCrop(object obj)
        {
            SelectedViewModel = new CropViewModel();
        }
        private void OpenFertiliser(object obj)
        {
            SelectedViewModel = new FertiliserViewModel();
        }
        private void OpenCategory(object obj)
        {
            SelectedViewModel = new CategoryViewModel();
        }
        private void OpenHarvest(object obj)
        {
            SelectedViewModel = new HarvestViewModel();
        }
        private void OpenProduct(object obj)
        {
            SelectedViewModel = new ProductViewModel();
        }
        private void OpenStock(object obj)
        {
            SelectedViewModel = new StockViewModel();
        }
        private void OpenStorage(object obj)
        {
            SelectedViewModel = new StorageViewModel();
        }
        private void OpenUser(object obj)
        {
            SelectedViewModel = new UserViewModel();
        }
        private void OpenVehicle(object obj)
        {
            SelectedViewModel = new VehicleViewModel();
        }

        private string pageName;

        public string PageName
        {
            get { return pageName; }
            set { pageName = value; }
        }
    }
}
