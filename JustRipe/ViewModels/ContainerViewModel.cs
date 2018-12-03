using JustRipe.Data.DTOs;
using JustRipe.Data.Repositories;
using JustRipe.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace JustRipe.ViewModels
{
   public class ContainerViewModel : ObservableObject
   {
      #region Fields
      private int _id;
      private string _name;
      private double _quantity;
      private string _unitType;
      private string _numContainers;
      private string _unit;
      private int _categoryId;
      private ObservableCollection<Object> _cropTable;
      private string _status;
      #endregion Fields



      public string Unit
      {
         get { return _unit; }
         set { _unit = value; OnPropertyChanged(nameof(Quantity)); }
      }


      public int CategoryId
      {
         get { return _categoryId; }
         set { _categoryId = value; OnPropertyChanged(nameof(Quantity)); }
      }


      #region Properties
      private Product selectedContainer;
      public string Status
      {
         get { return _status; }
         set { _status = value; }
      }
      public Product SelectedContainer
      {
         get { return selectedContainer; }
         set
         {
            if (value != null)
            {
               selectedContainer = value;
               FillUpdateCreateForm();
               OnPropertyChanged(nameof(SelectedContainer));
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

      private string _description;

      public string Description
      {
         get { return _description; }
         set { _description = value; OnPropertyChanged(nameof(Quantity)); }
      }

      public double Quantity
      {
         get { return _quantity; }
         set { _quantity = value; OnPropertyChanged(nameof(Quantity)); }
      }
      public string Available
      {
         get { return _numContainers; }
         set { _numContainers = value; OnPropertyChanged(nameof(Available)); }
      }
      public string UnitType
      {
         get { return _unitType; }
         set { _unitType = value; OnPropertyChanged(nameof(UnitType)); }
      }
      public RelayCommand AddUpdateContainerCommand { get; set; }
      public RelayCommand DeleteContainerCommand { get; set; }
      public RelayCommand ShowAllContainersToogleCommand { get; set; }

      #endregion Properties
      public ContainerViewModel()
      {
         AddUpdateContainerCommand = new RelayCommand(AddUpdateContainer);
         DeleteContainerCommand = new RelayCommand(DeleteContainer);
         ShowAllContainers();
      }
      void FillUpdateCreateForm()
      {
         Id = SelectedContainer.Id;
         Name = SelectedContainer.Name;
         Quantity = SelectedContainer.Quantity;
         Status = SelectedContainer.Status;
         UnitType = SelectedContainer.Unit;
      }
      private ProductRepository GetRepository()
      {
         return new ProductRepository(new Repository<ProductDTO>(), new Repository<CategoryDTO>());
      }

      private void ShowAllContainers()
      {
         var products = GetRepository().GetAllContainerProducts();
         ContainerTable = new ObservableCollection<Object>();
         BuildTable(products);
      }

      private void BuildTable(IEnumerable<Product> products)
      {
         foreach (var prod in products)

            ContainerTable.Add(
                new Product
                {
                   Id = prod.Id,
                   Name = prod.Name,
                   Description = prod.Description,
                   Quantity = prod.Quantity,
                   Status = prod.Status,
                   Unit = prod.Unit,
                   CategoryId = prod.CategoryId,
                   CategoryName = prod.CategoryName,
                });
      }
      public ObservableCollection<object> ContainerTable
      {
         get { return _cropTable; }
         set
         {
            if (value != null)
            {
               _cropTable = value;
               OnPropertyChanged(nameof(ContainerTable));
            }
         }
      }
      private void ClearForm()
      {

      }
      private void AddUpdateContainer(object parameter)
      {
         if (SelectedContainer == null)
         {
            AddContainer();
         }
         else
         {
            UpdateContainer();
            SelectedContainer = null;
         }

         ClearForm();

         ContainerTable.Clear();

         ShowAllContainers();
      }
      void AddContainer()
      {
         var newContainer = NewContainerDTO();

         GetRepository().AddProduct(newContainer);
      }
      void UpdateContainer()
      {
         var newContainer = NewContainerDTO();

         GetRepository().UpdateProduct(newContainer);

      }
      private ProductDTO NewContainerDTO()
      {
         return new ProductDTO
         {
            Id = Id,
            Name = Name,
            Description = Description,
            Quantity = Quantity,
            Status = Status,
            Unit = Unit,
            CategoryId = CategoryId,
         };
      }
      private void DeleteContainer(object parameter)
      {
         if (SelectedContainer != null)
         {
            ProductDTO newContainer = new ProductDTO
            {
               Id = Id,
            };
            GetRepository().DeleteProduct(newContainer);
            ShowAllContainers();
         }
      }

   }

}


