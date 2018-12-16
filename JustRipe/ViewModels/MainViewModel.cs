using JustRipe.Models;
using System.Windows;

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
      public RelayCommand TimeTableCommand { get; set; }
      public RelayCommand ProductCommand { get; set; }
      public RelayCommand StockCommand { get; set; }
      public RelayCommand ContainerCommand { get; set; }
      public RelayCommand UserCommand { get; set; }
      public RelayCommand VehicleCommand { get; set; }
      public RelayCommand LabourCommand { get; set; }

      private static string _loggedUserRole;

      public static string LoggedUserRole
      {
         get { return _loggedUserRole; }
         set
         {
            if (value != null)
            {
               _loggedUserRole = value;
            }

         }
      }
      private static string _loggedUserName;

      public static string LoggedUserName
      {
         get
         {
            return _loggedUserName;
         }
         set
         {
            _loggedUserName = value;
         }
      }
      private Visibility _menuVisibility;

      public Visibility MenuVisibility
      {
         get { return _menuVisibility; }
         set { _menuVisibility = value; OnPropertyChanged(nameof(MenuVisibility)); }
      }

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
      private static User _loggedUser;

      public static User LoggedUser
      {
         get { return _loggedUser; }
         set { _loggedUser = value; }
      }

      public MainViewModel()
      {
         if (LoggedUser != null)
         {
            LoggedUserName = "Welcome, " + LoggedUser.FirstName + " - " + LoggedUser.Role;

            MenuVisibility = LoggedUser.Role == "Manager" ? Visibility.Visible : Visibility.Collapsed;
         }

         /// Set the default View after login
         PageName = "Tasks";
         SelectedViewModel = new TaskViewModel();
         DashboardCommand = new RelayCommand(OpenDashboard);
         CropCommand = new RelayCommand(OpenCrop);
         FertiliserCommand = new RelayCommand(OpenFertiliser);
         CategoryCommand = new RelayCommand(OpenCategory);
         TimeTableCommand = new RelayCommand(OpenTimeTable);
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
         PageName = "Fertiliser";

         SelectedViewModel = new FertiliserViewModel();
      }
      private void OpenCategory(object obj)
      {
         PageName = "Categories";

         SelectedViewModel = new CategoryViewModel();
      }
      private void OpenTimeTable(object obj)
      {
         PageName = "Time Table";

         SelectedViewModel = new TimeTableViewModel();
      }
      private void OpenProduct(object obj)
      {
         PageName = "Products";

         //SelectedViewModel = new ProductViewModel();
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
