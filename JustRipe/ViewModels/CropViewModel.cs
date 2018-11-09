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
    public class CropViewModel : ObservableObject, IBaseViewModel
    {

        private Crop crop;

        public Crop Crop
        {
            get { return crop; }
            set { crop = value; }
        }

        public RelayCommand AddCropCommand { get; set; }


        public CropViewModel()
        {
            crop = new Crop("Crop Corn model name ");
            _color = Brushes.Red;
            PageName = "Crops";
            AddCropCommand = new RelayCommand(AddCrop);
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

        void AddCrop(object parameter)
        {
            User u = new User
            {
                Username = "fabio",
                Password = "lazzy"
            };

            //var omg = SqliteDataAccess.LoadUsers();
            //MessageBox.Show(omg.ToString());
        }
    }

}
