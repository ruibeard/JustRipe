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
            AddCategoryCommand = new RelayCommand(AddCategory);
        }
        void AddCategory(object parameter)
        {
           

        }
    }

}
