﻿using JustRipe.Data.DTOs;
using JustRipe.Data.Repositories;
using JustRipe.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace JustRipe.ViewModels
{
   public class ProductViewModel : ObservableObject
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

      private string _description;

      public string Description
      {
         get { return _description; }
         set { _description = value; OnPropertyChanged(nameof(Description)); }
      }

      private double _price;

      public double Price
      {
         get { return _price; }
         set { _price = value; OnPropertyChanged(nameof(Price)); }
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

      private string _unit;

      public string Unit
      {
         get { return _unit; }
         set { _unit = value; }
      }

      private bool _showingAll = false;

      public bool ShowingAll
      {
         get { return _showingAll; }
         set { _showingAll = value; OnPropertyChanged(nameof(ShowingAll)); }
      }

      private void ToogleTable(object param)
      {
         if (ShowingAll == false)
         {
            ShowProductsInStock();
            _showingAll = true;
         }
         else
         {
            ShowProductsInStock();
            _showingAll = false;
         }
      }

      public RelayCommand AddUpdateProductCommand { get; set; }
      public RelayCommand DeleteProductCommand { get; set; }
      public RelayCommand ShowAllProdutsToogleCommand { get; set; }
      #endregion Properties

      public ProductViewModel()
      {
         AddUpdateProductCommand = new RelayCommand(AddUpdateProduct);
         DeleteProductCommand = new RelayCommand(DeleteProduct);
         ShowAllProdutsToogleCommand = new RelayCommand(ToogleTable);
         ShowProductsInStock();
      }

      void FillUpdateCreateForm()
      {
         ShowForm();
         Id = SelectedProduct.Id;
         Name = SelectedProduct.Name;
         Quantity = SelectedProduct.Quantity;
         Price = SelectedProduct.Price;
         Unit = SelectedProduct.Unit;
         Description = selectedProduct.Description;
         CategoryName = SelectedProduct.CategoryName;
         CategoryId = SelectedProduct.CategoryId;
      }

      private ProductRepository GetRepository()
      {
         return new ProductRepository(new Repository<ProductDTO>(), new Repository<CategoryDTO>());
      }

      private void ShowAllProducts(object param)
      {
         var products = GetRepository().GetAllProducts();
         ProductTable = new ObservableCollection<Object>();
         BuildTable(products);
      }

      private void ShowProductsInStock()
      {
         var products = GetRepository().GetAllProductsCurrentlyInStock();
         ProductTable = new ObservableCollection<Object>();
         BuildTable(products);
      }

      private void BuildTable(IEnumerable<Product> products)
      {
         foreach (var prod in products)
         {
            ProductTable.Add(
                new Product
                {
                   Id = prod.Id,
                   Name = prod.Name,
                   Description = prod.Description,
                   Quantity = prod.Quantity,
                   Price = prod.Price,
                   Unit = prod.Unit,
                   CategoryId = prod.CategoryId,
                   CategoryName = prod.CategoryName,
                });
         }
      }

      private ObservableCollection<Object> _productTable;
      public ObservableCollection<object> ProductTable
      {
         get { return _productTable; }
         set
         {
            if (value != null)
            {
               _productTable = value;
               OnPropertyChanged(nameof(ProductTable));
            }
         }
      }

      private void AddUpdateProduct(object parameter)
      {
         if (SelectedProduct == null) { AddProduct(parameter); }
         else
         {
            UpdateProduct(parameter);
            SelectedProduct = null;
         }
         Name = CategoryName = Description = Unit = "";
         Id = 0;
         Quantity = CategoryId = 0;
         ProductTable.Clear();
         ShowProductsInStock();
         HideForm();
      }

      void AddProduct(object parameter)
      {
         ProductDTO newProduct = new ProductDTO
         {
            Name = Name,
            Quantity = Quantity,
            Price = Price,
            Description = Description,
            CategoryId = CategoryId,
         };
         GetRepository().AddProduct(newProduct);

      }

      void UpdateProduct(object parameter)
      {
         ProductDTO newProduct = new ProductDTO
         {
            Name = Name,
            Quantity = Quantity,
            CategoryId = CategoryId,
         };
         GetRepository().UpdateProduct(newProduct);

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
            ShowProductsInStock();
         }
      }

   }

}
