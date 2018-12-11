using JustRipe.Data.DTOs;
using JustRipe.Data.Repositories;
using JustRipe.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace JustRipe.ViewModels
{
   public class FertiliserViewModel : ObservableObject
   {

      #region Fields
      private int _id;
      private string _name;

      #endregion Fields

      #region Properties
      private Product selectedProduct;
      public Product SelectedProduct
      {
         get { return selectedProduct; }
         set
         {
            if (value != null)
            {
               selectedProduct = value;
               FillUpdateCreateForm();
               OnPropertyChanged(nameof(SelectedProduct));
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
      private int _categoryId;
      public int CategoryId
      {
         get { return _categoryId; }
         set { _categoryId = value; OnPropertyChanged(nameof(CategoryId)); }
      }
      private string _categoryName;
      public string CategoryName
      {
         get { return _categoryName; }
         set { _categoryName = value; OnPropertyChanged(nameof(CategoryName)); }
      }
      private double _quantity;
      public double Quantity
      {
         get { return _quantity; }
         set { _quantity = value; OnPropertyChanged(nameof(Quantity)); }
      }

      private string _description;
      public string Description
      {
         get { return _description; }
         set { _description = value; OnPropertyChanged(nameof(Description)); }
      }

      private string _status;
      public string Status
      {
         get { return _status; }
         set { _status = value; OnPropertyChanged(nameof(Description)); }
      }

      private string _unit;
      public string Unit
      {
         get { return _unit; }
         set { _unit = value; OnPropertyChanged(nameof(Unit)); }
      }

      private decimal _price;
      public decimal Price
      {
         get { return _price; }
         set { _price = value; OnPropertyChanged(nameof(Price)); }
      }

      public RelayCommand AddUpdateProductCommand { get; set; }
      public RelayCommand DeleteProductCommand { get; set; }
      public RelayCommand ShowAllProductsCommand { get; set; }
      #endregion Properties

      public FertiliserViewModel()
      {
         AddUpdateProductCommand = new RelayCommand(AddUpdateProduct);
         DeleteProductCommand = new RelayCommand(DeleteProduct);
         ShowAllProductsCommand = new RelayCommand(ShowFertilisers);
         ShowFertilisers();
      }

      void FillUpdateCreateForm()
      {
         ShowForm();
         Id = SelectedProduct.Id;
         Name = SelectedProduct.Name;
         Quantity = SelectedProduct.Quantity;
         Description = SelectedProduct.Description;
         Unit = SelectedProduct.Unit;
         Price = SelectedProduct.Price;
         CategoryName = SelectedProduct.CategoryName;
         CategoryId = SelectedProduct.CategoryId;
      }

      private ProductRepository GetRepository()
      {
         return new ProductRepository(new Repository<ProductDTO>(), new Repository<CategoryDTO>());
      }

      private void ShowFertilisers(object param = null)
      {
         var products = GetRepository().GetAllFertiliserProducts();
         FertiliserTable = new ObservableCollection<Object>();
         BuildTable(products);
      }

      private void GetAllFertilisersProductsCurrentlyInStock()
      {
         var products = GetRepository().GetAllFertilizersProductsCurrentlyInStock();
         FertiliserTable = new ObservableCollection<Object>();
         BuildTable(products);
      }

      private void BuildTable(IEnumerable<Product> products)
      {
         FertiliserTable.Clear();
         foreach (var prod in products)
         {
            FertiliserTable.Add(
                new Product
                {
                   Id = prod.Id,
                   Name = prod.Name,
                   Quantity = prod.Quantity,
                   Description = prod.Description,
                   Unit = prod.Unit,
                   Price = prod.Price,
                   CategoryId = prod.CategoryId,
                   CategoryName = prod.CategoryName,
                });
         }
      }

      private ObservableCollection<Object> _productTable;
      public ObservableCollection<object> FertiliserTable
      {
         get { return _productTable; }
         set
         {
            if (value != null)
            {
               _productTable = value;
               OnPropertyChanged(nameof(FertiliserTable));
            }
         }
      }

      private void AddUpdateProduct(object parameter)
      {
         FertiliserTable.Clear();

         if (SelectedProduct == null) { AddProduct(parameter); }
         else
         {
            UpdateProduct(parameter);
            SelectedProduct = null;
         }
         Name = CategoryName;
         Id = 0;
         Quantity = CategoryId = 0;
         ShowFertilisers();
         HideForm();
      }

      void AddProduct(object parameter)
      {
         var newProduct = NewDTO();

         GetRepository().AddProduct(newProduct);
      }

      void UpdateProduct(object parameter)
      {
         var newProduct = NewDTO();

         GetRepository().UpdateProduct(newProduct);

      }

      private ProductDTO NewDTO()
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

      private void DeleteProduct(object parameter)
      {
         if (SelectedProduct != null)
         {
            ProductDTO newProduct = new ProductDTO
            {
               Id = Id,
            };
            GetRepository().DeleteProduct(newProduct);
            ShowFertilisers();
         }
      }
   }

}
