﻿using JustRipe.Data.DTOs;
using JustRipe.Data.Repositories;
using JustRipe.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace JustRipe.ViewModels
{
    public class StockViewModel : ObservableObject
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

        private string _description;

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value; OnPropertyChanged(nameof(Description));

            }
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



        public RelayCommand AddUpdateProductCommand { get; set; }
        public RelayCommand DeleteProductCommand { get; set; }
        public RelayCommand ShowAllProductsCommand { get; set; }
        #endregion Properties

        public StockViewModel()
        {
            AddUpdateProductCommand = new RelayCommand(AddUpdateProduct);
            DeleteProductCommand = new RelayCommand(DeleteProduct);
            ShowAllProductsCommand = new RelayCommand(ShowAllProducts);
            ShowProductsInStock();
        }

        void FillUpdateCreateForm()
        {
            Id = SelectedProduct.Id;
            Name = SelectedProduct.Name;
            Description = SelectedProduct.Description;
            Quantity = SelectedProduct.Quantity;
            CategoryName = SelectedProduct.CategoryName;
            CategoryId = SelectedProduct.CategoryId;
        }

        private ProductRepository GetRepository()
        {
            return new ProductRepository(new Repository<ProductDTO>(), new Repository<CategoryDTO>());
        }


        private void ShowAllProducts(object param)
        {
            var crops = GetRepository().GetAllProducts();
            ProductTable = new ObservableCollection<Object>();
            BuildTable(crops);
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
                        Quantity = prod.Quantity,
                        CategoryId = prod.CategoryId,
                        CategoryName = prod.CategoryName,
                    });
            }
        }

        private ObservableCollection<Object> _cropTable;
        public ObservableCollection<object> ProductTable
        {
            get { return _cropTable; }
            set
            {
                if (value != null)
                {
                    _cropTable = value;
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
            Name = CategoryName;
            Id = 0;
            Quantity = CategoryId = 0;
            ProductTable.Clear();
            ShowProductsInStock();
        }

        void AddProduct(object parameter)
        {
            ProductDTO newProduct = new ProductDTO
            {
                Name = Name,
                Quantity = Quantity,
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

        //void AddProduct(object parameter)
        //{
        //    GetRepository().AddProduct(new Product { Name = Name, Stage = Stage, Area = Area, Type = Type });
        //}
    }

}