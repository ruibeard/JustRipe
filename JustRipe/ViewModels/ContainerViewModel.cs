using JustRipe.Data.DTOs;
using JustRipe.Data.Repositories;
using JustRipe.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace JustRipe.ViewModels
{
   public class ContainerViewModel : ObservableObject
   {
      #region Fields
      private int _id;
      private string _name;
      private double _quantity;
      private string _unit;
      private string _available;
      private int _categoryId = 2;
      private string _status;
      private ObservableCollection<Object> _containerTable;
      private Product selectedContainer;

      #endregion Fields

      #region Properties
      public Product SelectedContainer
      {
         get { return selectedContainer; }
         set
         {
            if (value != null)
            {
               selectedContainer = value;
               OnPropertyChanged(nameof(SelectedContainer));
               FillUpdateCreateForm();
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
         set { _description = value; OnPropertyChanged(nameof(Description)); }
      }
      public double Quantity
      {
         get { return _quantity; }
         set { _quantity = value; OnPropertyChanged(nameof(Quantity)); }
      }

      public string Available
      {
         get { return _available; }
         set { _available = value; OnPropertyChanged(nameof(Available)); }
      }

      public string Unit
      {
         get { return _unit; }
         set { _unit = value; OnPropertyChanged(nameof(Unit)); }
      }

      public string Status
      {
         get { return _status; }
         set { _status = value; OnPropertyChanged(nameof(Status)); }
      }
      public int CategoryId
      {
         get { return _categoryId; }
         set { _categoryId = value; OnPropertyChanged(nameof(Quantity)); }
      }
      public RelayCommand AddUpdateCommand { get; set; }
      public RelayCommand DeleteCommand { get; set; }
      public RelayCommand AddCommand { get; set; }

      #endregion Properties
      public ContainerViewModel()
      {
         AddUpdateCommand = new RelayCommand(AddUpdateContainer);
         DeleteCommand = new RelayCommand(DeleteContainer);
         AddCommand = new RelayCommand(ShowFormAndClear);
         ShowAllContainers();
      }


      private void ShowFormAndClear(object param = null)
      {
         ClearForm();
         ShowForm();
      }
      void FillUpdateCreateForm()
      {
         ShowForm();
         Id = SelectedContainer.Id;
         Name = SelectedContainer.Name;
         Description = SelectedContainer.Description;
         Quantity = SelectedContainer.Quantity;
         Unit = SelectedContainer.Unit;
         Status = SelectedContainer.Status;
         CategoryId = SelectedContainer.CategoryId;
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
         get { return _containerTable; }
         set
         {
            if (value != null)
            {
               _containerTable = value;
               OnPropertyChanged(nameof(ContainerTable));
            }
         }
      }
      private void ClearForm()
      {
         Name = Description = Status = Unit = String.Empty;
         Id = CategoryId = default(int);
         Quantity = 0;
         //var props = this.GetType().GetProperties(System.Reflection.BindingFlags.Public);
         //foreach (var i in props)
         //{
         //   var again = i.PropertyType;
         //   i.SetValue(this, default());
         //}
      }
      private void AddUpdateContainer(object parameter)
      {
         ContainerTable.Clear();
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
         ShowAllContainers();
         HideForm();
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


