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
    public class StorageViewModel : ObservableObject, IBaseViewModel
    {

        private Storage storage;

        public Storage Storage
        {
            get { return storage; }
            set { storage= value; }
        }

        public RelayCommand AddStorageCommand { get; set; }


        public StorageViewModel()
        {
            storage= new Storage("Storage  model name ");
            _color = Brushes.Red;
            PageName = "Storages";
            AddStorageCommand = new RelayCommand(AddStorage);
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

        void AddStorage(object parameter)
        {
            User u = new User
            {
                Username = "fabio",
                Password = "lazzy"
            };

        }
    }

}
