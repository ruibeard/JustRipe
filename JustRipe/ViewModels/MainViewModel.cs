using JustRipe.Models;

namespace JustRipe.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        /// <summary>
        /// Properties that we use in every menu button on the main view.
        /// </summary>
        public RelayCommand DashboardCommand { get; set; }
        public RelayCommand CropCommand { get; set; }
        public RelayCommand TaskCommand { get; set; }
        public RelayCommand FertiliserCommand { get; set; }
        public RelayCommand CategoryCommand { get; set; }
        public RelayCommand HarvestCommand { get; set; }
        public RelayCommand ProductCommand { get; set; }
        public RelayCommand StockCommand { get; set; }
        public RelayCommand ContainerCommand { get; set; }
        public RelayCommand UserCommand { get; set; }
        public RelayCommand VehicleCommand { get; set; }
        public RelayCommand LabourCommand { get; set; }

        

        private string _pageName;

        public string PageName
        {
            get { return _pageName; }
            set
            {
                _pageName = value;
                OnPropertyChanged(nameof(PageName));
            }
        }

        private object selectedViewModel;

        public object SelectedViewModel
        {
            get { return selectedViewModel; }
            set { selectedViewModel = value; OnPropertyChanged(nameof(SelectedViewModel)); }
        }


        public MainViewModel()
        {
            /// Set the default View after login
            PageName = "Tasks";
            SelectedViewModel = new TaskViewModel();


            DashboardCommand = new RelayCommand(OpenDashboard);
            CropCommand = new RelayCommand(OpenCrop);
            FertiliserCommand = new RelayCommand(OpenFertiliser);
            CategoryCommand = new RelayCommand(OpenCategory);
            HarvestCommand = new RelayCommand(OpenHarvest);
            ProductCommand = new RelayCommand(OpenProduct);
            StockCommand = new RelayCommand(OpenStock);
            ContainerCommand = new RelayCommand(OpenContainer);
            UserCommand = new RelayCommand(OpenUser);
            VehicleCommand = new RelayCommand(OpenVehicle);
            TaskCommand = new RelayCommand(OpenTask);
            LabourCommand = new RelayCommand(OpenLabour);
        }

        private void OpenDashboard(object obj)
        {
            PageName = "Dashboard";
            SelectedViewModel = new DashBoardViewModel();
        }
        private void OpenCrop(object obj)
        {
            PageName = "Crops";

            SelectedViewModel = new CropViewModel();
        }
        private void OpenTask(object obj)
        {
            PageName = "Tasks";

            SelectedViewModel = new TaskViewModel();
        }
        private void OpenFertiliser(object obj)
        {
            PageName = "Fertilizer";

            SelectedViewModel = new FertiliserViewModel();
        }
        private void OpenCategory(object obj)
        {
            PageName = "Categories";

            SelectedViewModel = new CategoryViewModel();
        }
        private void OpenHarvest(object obj)
        {
            PageName = "Harvesting";

            SelectedViewModel = new HarvestViewModel();
        }
        private void OpenProduct(object obj)
        {
            PageName = "Products";

            SelectedViewModel = new ProductViewModel();
        }
        private void OpenStock(object obj)
        {
            PageName = "Stock";

            SelectedViewModel = new StockViewModel();
        }
        private void OpenContainer(object obj)
        {
            PageName = "Containers";

            SelectedViewModel = new ContainerViewModel();
        }
        private void OpenUser(object obj)
        {
            PageName = "Users";
            SelectedViewModel = new UserViewModel();
        }
        private void OpenVehicle(object obj)
        {
            PageName = "Vehicles";
            SelectedViewModel = new VehicleViewModel();
        }
        private void OpenLabour(object obj)
        {
            PageName = "Labour";
            SelectedViewModel = new LabourerViewModel();
        }
    }
}
