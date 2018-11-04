using JustRipe.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustRipe.ViewModels
{
    class ViewModelCrop : ViewModelBase
    {
        public ObservableCollection<Crops> Crop { get; set; }
        
        object _SelectedCrop;
        public object SelectedCrop
        {
            get
            {
                return _SelectedCrop;
            }
            set
            {
                if (_SelectedCrop != value)
                {
                    _SelectedCrop = value;
                    RaisePropertyChanged("SelectedCrop");
                }
            }
        }

        string _TextProperty1;
        public string TextProperty1
        {
            get
            {
                return _TextProperty1;
            }
            set
            {
                if (_TextProperty1 != value)
                {
                    _TextProperty1 = value;
                    RaisePropertyChanged("TextProperty1");
                }
            }
        }

        public Dispatch AddUserCommand { get; set; }

        public ViewModelCrop()
        {
            Crop = new ObservableCollection<Crop>
            {
                new Crop { FirstName="Tom", LastName="Jones", Age=80 },
                new Crop { FirstName="Dick", LastName="Tracey", Age=40 },
                new Crop { FirstName="Harry", LastName="Hill", Age=60 },
            };
            TextProperty1 = "Type here";

            AddUserCommand = new RelayCommand(AddUser);
        }



        void AddUser(object parameter)
        {
            if (parameter == null) return;
            Crop.Add(new Crop { FirstName = parameter.ToString(), LastName = parameter.ToString(), Age = DateTime.Now.Second });
        }

    }

}
