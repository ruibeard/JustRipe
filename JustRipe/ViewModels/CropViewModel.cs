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
      private int _productId;
      private Crop selectedCrop;
      private ObservableCollection<Object> _cropTable = new ObservableCollection<Object>();

      private List<Product> _productList = new List<Product>();


      private string _productName;
      #endregion Fields


      #region Properties

      public List<Product> ProductList
      {
         get { return _productList; }
         set
         {
            _productList = value;
            OnPropertyChanged(nameof(ProductList));
         }
      }
      public bool ShowingAll
      {
         get { return _showingAll; }
         set { _showingAll = value; OnPropertyChanged(nameof(ShowingAll)); }
      }
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
      public int ProductId
      {
         get { return _productId; }
         set { _productId = value; OnPropertyChanged(nameof(ProductId)); }
      }
      public string ProductName
      {
         get { return _productName; }
         set { _productName = value; OnPropertyChanged(nameof(ProductName)); }
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
      public RelayCommand AddCropCommand { get; set; }

      #endregion Properties
      public CropViewModel()
      {
         AddUpdateCropCommand = new RelayCommand(AddUpdateCrop);
         DeleteCropCommand = new RelayCommand(DeleteCrop);
         ShowAllCropsToogleCommand = new RelayCommand(ToogleTable);
         AddCropCommand = new RelayCommand(ShowFormAndClear);
         
         ShowCropsInCultivation();
         GetAllContainers();

      }
      void FillUpdateCreateForm()
      {
         ShowForm();
         Id = SelectedCrop.Id;
         Name = SelectedCrop.Name;
         Stage = SelectedCrop.Stage;
         Type = SelectedCrop.Type;
         Area = SelectedCrop.Area;
         NumContainers = SelectedCrop.NumContainers;
         StorageRequired = SelectedCrop.StorageRequired;
         ProductId = SelectedCrop.ProductId;
         ProductName = SelectedCrop.ProductName;
      }
      private CropRepository GetRepository()
      {
         return new CropRepository(new Repository<CropDTO>(), new Repository<ProductDTO>(), new Repository<CategoryDTO>());
      }

      private void ShowFormAndClear(object param = null)
      {
         ShowForm();
         ClearForm();
      }
      private void ToogleTable(object param = null)
      {
         CropTable.Clear();

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
         var crops = GetRepository().GetAllCropsAndContainers();
         BuildTable(crops);
      }
      private void ShowCropsInCultivation()
      {
         var crops = GetRepository().GetAllCropsCurrentlyInCultivation();
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
                   ProductName = crop.ProductName,
                   ProductId = crop.ProductId
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
      private ProductRepository GetProductRepository()
      {
         return new ProductRepository(new Repository<ProductDTO>(), new Repository<CategoryDTO>());
      }
      private void GetAllContainers()
      {
         var all_Containers = GetProductRepository().GetAllContainerProducts();

         foreach (var container in all_Containers)
         {
            ProductList.Add(new Product { Id = container.Id, ProductName = container.Name });
         }
      }
      private void AddUpdateCrop(object parameter)
      {
         CropTable.Clear();

         if (SelectedCrop == null)
         {
            ShowFormAndClear();
         }
         else
         {
            UpdateCrop();
            SelectedCrop = null;
         }
         ClearForm();
         if (ShowingAll)
            ShowAllCrops();
         else
            ShowCropsInCultivation();
         HideForm();
      }

      void ShowFormAndClear()
      {
         var newCrop = NewCropDTO();
         GetRepository().AddCrop(newCrop);
      }
      void UpdateCrop()
      {
         var newCrop = NewCropDTO();
         GetRepository().UpdateCrop(newCrop);
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
            ProductId = ProductId,
         };
      }
   }
}