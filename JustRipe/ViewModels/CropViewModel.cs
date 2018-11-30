using JustRipe.Data.DTOs;
using JustRipe.Data.Repositories;
using JustRipe.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace JustRipe.ViewModels
{
   public class CropViewModel : ObservableObject
   {
      #region Fields
      private int _id;
      private string _name;
      private string _area;
      private string _stage;
      private string _type;
      private string _storageRequired;
      private int _numContainers;
      private bool _showingAll = false;
      private ObservableCollection<Object> _cropTable;
      #endregion Fields

      public bool ShowingAll
      {
         get { return _showingAll; }
         set { _showingAll = value; OnPropertyChanged(nameof(ShowingAll)); }
      }
      #region Properties
      private Crop selectedCrop;
      public Crop SelectedCrop
      {
         get { return selectedCrop; }
         set
         {
            if (value != null)
            {
               selectedCrop = value;
               FillUpdateCreateForm();
               OnPropertyChanged(nameof(SelectedCrop));
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
      public string Type
      {
         get { return _type; }
         set { _type = value; OnPropertyChanged(nameof(Type)); }
      }
      public string Stage
      {
         get { return _stage; }
         set { _stage = value; OnPropertyChanged(nameof(Stage)); }
      }
      public string Area
      {
         get { return _area; }
         set { _area = value; OnPropertyChanged(nameof(Area)); }
      }
      public int NumContainers
      {
         get { return _numContainers; }
         set { _numContainers = value; OnPropertyChanged(nameof(NumContainers)); }
      }
      public string StorageRequired
      {
         get { return _storageRequired; }
         set { _storageRequired = value; OnPropertyChanged(nameof(StorageRequired)); }
      }
      public RelayCommand AddUpdateCropCommand { get; set; }
      public RelayCommand DeleteCropCommand { get; set; }
      public RelayCommand ShowAllCropsToogleCommand { get; set; }

      #endregion Properties
      public CropViewModel()
      {
         AddUpdateCropCommand = new RelayCommand(AddUpdateCrop);
         DeleteCropCommand = new RelayCommand(DeleteCrop);
         ShowAllCropsToogleCommand = new RelayCommand(ToogleTable);
         ShowCropsInCultivation();
      }
      void FillUpdateCreateForm()
      {
         Id = SelectedCrop.Id;
         Name = SelectedCrop.Name;
         Stage = SelectedCrop.Stage;
         Type = SelectedCrop.Type;
         Area = SelectedCrop.Area;
         NumContainers = SelectedCrop.NumContainers;
         StorageRequired = SelectedCrop.StorageRequired;
      }
      private CropRepository GetRepository()
      {
         return new CropRepository(new Repository<CropDTO>());
      }
      private void ToogleTable(object param)
      {
         Console.WriteLine(param);
         if (ShowingAll == false)
         {
            ShowAllCrops();
            _showingAll = true;
         }
         else
         {
            ShowCropsInCultivation();
            _showingAll = false;
         }
      }
      private void ShowAllCrops()
      {

         var crops = GetRepository().GetAllCrops();
         CropTable = new ObservableCollection<Object>();
         BuildTable(crops);
      }
      private void ShowCropsInCultivation()
      {
         var crops = GetRepository().GetAllCropsCurrentlyInCultivation();
         CropTable = new ObservableCollection<Object>();
         BuildTable(crops);
      }
      private void BuildTable(IEnumerable<Crop> crops)
      {
         foreach (var crop in crops)
         {
            CropTable.Add(
                new Crop
                {
                   Id = crop.Id,
                   Name = crop.Name,
                   Stage = crop.Stage,
                   Type = crop.Type,
                   Area = crop.Area,
                   NumContainers = crop.NumContainers,
                   StorageRequired = crop.StorageRequired,
                });
         }
      }
      public ObservableCollection<object> CropTable
      {
         get { return _cropTable; }
         set
         {
            if (value != null)
            {
               _cropTable = value;
               OnPropertyChanged(nameof(CropTable));
            }
         }
      }
      private void ClearForm()
      {
         Name = Stage = Type = Area = StorageRequired = "";
         Id = NumContainers = 0;

      }
      private void AddUpdateCrop(object parameter)
      {
         if (SelectedCrop == null)
         {
            AddCrop();
         }
         else
         {
            UpdateCrop();
            SelectedCrop = null;
         }

         ClearForm();

         CropTable.Clear();

         if (ShowingAll)
            ShowAllCrops();
         else
            ShowCropsInCultivation();
      }
      void AddCrop()
      {
         var newCrop = NewCropDTO();

         GetRepository().AddCrop(newCrop);


      }
      void UpdateCrop()
      {
         var newCrop = NewCropDTO();

         GetRepository().UpdateCrop(newCrop);

      }
      private CropDTO NewCropDTO()
      {
         return new CropDTO
         {
            Id = Id,
            Name = Name,
            Stage = Stage,
            Type = Type,
            Area = Area,
            NumContainers = NumContainers,
            StorageRequired = StorageRequired,

         };
      }
      private void DeleteCrop(object parameter)
      {
         if (SelectedCrop != null)
         {
            CropDTO newCrop = new CropDTO
            {
               Id = Id,
            };
            GetRepository().DeleteCrop(newCrop);
            ShowCropsInCultivation();
         }
      }

   }

}