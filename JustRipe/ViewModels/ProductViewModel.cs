using JustRipe.Data;
using JustRipe.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace JustRipe.ViewModels
{
    public class ProductViewModel : ObservableObject, IBaseViewModel
    {

        private Product product;

        public Product Product
        {
            get { return product; }
            set { product = value; }
        }

        public RelayCommand AddProductCommand { get; set; }


        public ProductViewModel()
        {
            product = new Product("Product  model name ");
            _color = Brushes.Red;
            PageName = "Products";
            AddProductCommand = new RelayCommand(AddProduct);
        }
        private string pageName;

        public string PageName
        {
            get { return pageName; }
            set { pageName = value; }
        }


        private Brush _color;

        public Brush Color
        {
            get { return _color; }
            set { _color = value; }
        }

        void AddProduct(object parameter)
        {
            User u = new User
            {
                Username = "fabio",
                Password = "lazzy"
            };

        }
    }

}
