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
    public class CategoryViewModel : ObservableObject
    {

        private Category category;

        public Category Category
        {
            get { return category; }
            set { category = value; }
        }

        public RelayCommand AddCategoryCommand { get; set; }


        public CategoryViewModel()
        {
            category = new Category("Category Corn model name ");
            _color = Brushes.Red;
            PageName = "Categorys";
            AddCategoryCommand = new RelayCommand(AddCategory);
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

        void AddCategory(object parameter)
        {
           

        }
    }

}
