using JustRipe.Data.DTOs;
using JustRipe.Data.Repositories;
using JustRipe.Models;
using System;
using System.Collections.ObjectModel;

namespace JustRipe.ViewModels
{
   public class VehicleViewModel : ObservableObject
   {
      #region Fields
      private int _id;
      private string _name;
      private string _year;
      private string _type;
      private string _brand;
      private string _model;
      private string _capacity;
      private string _licencePlate;
      private string _status;
      #endregion Fields

      #region Properties
      private Vehicle selectedVehicle;
      public Vehicle SelectedVehicle
      {
         get { return selectedVehicle; }
         set
         {
            if (value != null)
            {
               selectedVehicle = value;
               FillUpdateCreateForm();
               OnPropertyChanged(nameof(SelectedVehicle));
            }
         }
      }
      public int Id
      {
         get { return _id; }
         set { _id = value; OnPropertyChanged(nameof(Id)); }
      }
      public string Name
      {
         get { return _name; }
         set { _name = value; OnPropertyChanged(nameof(Name)); }
      }

      public string Year
      {
         get { return _year; }
         set { _year = value; OnPropertyChanged(nameof(Year)); }
      }

      public string Type
      {
         get { return _type; }
         set { _type = value; OnPropertyChanged(nameof(Type)); }
      }

      public string Brand
      {
         get { return _brand; }
         set { _brand = value; OnPropertyChanged(nameof(Brand)); }
      }

      public string Model
      {
         get { return _model; }
         set { _model = value; OnPropertyChanged(nameof(Model)); }
      }

      public string Capacity
      {
         get { return _capacity; }
         set { _capacity = value; OnPropertyChanged(nameof(Capacity)); }
      }

      public string LicencePlate
      {
         get { return _licencePlate; }
         set { _licencePlate = value; OnPropertyChanged(nameof(LicencePlate)); }
      }

      public string Status
      {
         get { return _status; }
         set { _status = value; OnPropertyChanged(nameof(Status)); }
      }

      public RelayCommand AddOrUpdateCommand { get; set; }
      public RelayCommand DeleteCommand { get; set; }
      #endregion Properties
      public VehicleViewModel()
      {
         FillAllVehicles();
         AddOrUpdateCommand = new RelayCommand(AddOrUpdate);
         DeleteCommand = new RelayCommand(Delete);
      }
      void FillUpdateCreateForm()
      {
         ShowForm();
         Id = SelectedVehicle.Id;
         Name = SelectedVehicle.Name;
         Year = SelectedVehicle.Year;
         Type = SelectedVehicle.Type;
         Brand = SelectedVehicle.Brand;
         Model = SelectedVehicle.Model;
         Capacity = SelectedVehicle.Capacity;
         LicencePlate = SelectedVehicle.LicencePlate;
         Status = SelectedVehicle.Status;
      }
      private VehicleRepository GetRepository()
      {
         return new VehicleRepository(new Repository<VehicleDTO>());
      }
      private void FillAllVehicles()
      {
         var vehicles = GetRepository().GetAllVehicles();
         VehicleTable = new ObservableCollection<Object>();

         foreach (var vehicle in vehicles)
         {
            VehicleTable.Add(
                new Vehicle
                {
                   Id = vehicle.Id,
                   Name = vehicle.Name,
                   Year = vehicle.Year,
                   Type = vehicle.Type,
                   Brand = vehicle.Brand,
                   Model = vehicle.Model,
                   Capacity = vehicle.Capacity,
                   LicencePlate = vehicle.LicencePlate,
                   Status = vehicle.Status,
                });
         }
      }
      private ObservableCollection<Object> _vehicleTable;
      public ObservableCollection<object> VehicleTable
      {
         get { return _vehicleTable; }
         set
         {
            if (value != null)
            {
               _vehicleTable = value;
               OnPropertyChanged(nameof(VehicleTable));
            }
         }
      }
      private void AddOrUpdate(object parameter)
      {
         if (SelectedVehicle == null)
         {
            AddVehicle();
         }
         else
         {
            UpdateVehicle();
            SelectedVehicle = null;
         }
         Name = Year = Type = Brand = Model = Capacity = LicencePlate = Status = "";
         Id = 0;
         VehicleTable.Clear();
         FillAllVehicles();
         HideForm();
      }
      void AddVehicle()
      {
         VehicleDTO newVehicle = NewDTO();
         GetRepository().AddVehicle(newVehicle);
      }
      void UpdateVehicle()
      {
         VehicleDTO newVehicle = NewDTO();
         GetRepository().UpdateVehicle(newVehicle);
         FillAllVehicles();
      }
      private void Delete(object parameter)
      {
         if (SelectedVehicle != null)
         {
            VehicleDTO vehicle = new VehicleDTO
            {
               Id = Id,
            };
            GetRepository().DeleteVehicle(vehicle);
            FillAllVehicles();
         }
      }
      private VehicleDTO NewDTO()
      {
         return new VehicleDTO
         {
            Id = Id,
            Name = Name,
            Year = Year,
            Type = Type,
            Brand = Brand,
            Model = Model,
            Capacity = Capacity,
            LicencePlate = LicencePlate,
            Status = Status,
         };
      }
   }
}
