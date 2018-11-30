using JustRipe.Data.DTOs;
using JustRipe.Data.Repositories;
using JustRipe.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace JustRipe.ViewModels
{
    public class StockViewModel : ObservableObject
    {
        #region Fields

        private int _id;
        private string _name;
        public RelayCommand AddUpdateProductCommand { get; set; }
        public RelayCommand DeleteProductCommand { get; set; }
        public RelayCommand ShowAllProdutsToogleCommand { get; set; }
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
        private List<Category> _categoryList = new List<Category>();

        public List<Category> CategoryList
        {
            get { return _categoryList; }
            set
            {
                _categoryList = value;
                OnPropertyChanged(nameof(CategoryList));
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

        private string _unit;
        public string Unit
        {
            get { return _unit; }
            set { _unit = value; OnPropertyChanged(nameof(Unit)); }
        }

        private double _quantity;

        public double Quantity
        {
            get { return _quantity; }
            set { _quantity = value; OnPropertyChanged(nameof(Quantity)); }
        }

        private bool _isToogleEnabled = false;

        public bool IsToogleEnabled
        {
            get { return _isToogleEnabled; }
            set { _isToogleEnabled = value; OnPropertyChanged(nameof(IsToogleEnabled)); }
        }

        private void ToogleTable(object param)
        {
            if (IsToogleEnabled == false)
            {
                ShowAllProducts();
                _isToogleEnabled = true;
            }
            else
            {
                ShowProductsInStock();
                _isToogleEnabled = false;
            }
        }

        #endregion Properties

        public StockViewModel()
        {
            AddUpdateProductCommand = new RelayCommand(AddUpdateProduct);
            DeleteProductCommand = new RelayCommand(DeleteProduct);
            ShowAllProdutsToogleCommand = new RelayCommand(ToogleTable);
            ShowProductsInStock();
            GetAllCategories();

        }

        void FillUpdateCreateForm()
        {
            Id = SelectedProduct.Id;
            Name = SelectedProduct.Name;
            Description = SelectedProduct.Description;
            Quantity = SelectedProduct.Quantity;
            CategoryName = SelectedProduct.CategoryName;
            CategoryId = SelectedProduct.CategoryId;
            Unit = SelectedProduct.Unit;

        }

        private ProductRepository GetProductRepo()
        {
            return new ProductRepository(new Repository<ProductDTO>(), new Repository<CategoryDTO>());
        }

        private CategoryRepository GetCategoryRepo()
        {
            return new CategoryRepository(new Repository<CategoryDTO>());
        }


        private CropRepository GetCropRepository()
        {
            return new CropRepository(new Repository<CropDTO>());
        }

        private void ShowAllProducts()
        {
            var crops = GetProductRepo().GetAllProducts();
            BuildTable(crops);
        }

        private void ShowProductsInStock()
        {
            var products = GetProductRepo().GetAllProductsCurrentlyInStock();
            ProductTable = new ObservableCollection<Object>();
            BuildTable(products);
        }


        private void GetAllCategories()
        {
            var allCategories = GetCategoryRepo().GetAllCategories();

            foreach (var category in allCategories)
            {
                CategoryList.Add(new Category { Id = category.Id, Name = category.Name });
            }
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
            if (SelectedProduct == null)
            {
                AddProduct(parameter);
            }
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
            ProductDTO newProduct = NewProductDTO();

            GetProductRepo().AddProduct(newProduct);
        }

        void UpdateProduct(object parameter)
        {
            ProductDTO newProduct = NewProductDTO();
            GetProductRepo().UpdateProduct(newProduct);

        }

        private ProductDTO NewProductDTO()
        {
            return new ProductDTO
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Quantity = Quantity,
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
                GetProductRepo().DeleteProduct(newProduct);
                ShowProductsInStock();
            }
        }
    }
}