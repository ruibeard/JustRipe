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
    public class VehicleViewModel : ObservableObject
    {

        private Vehicle vehicle;

        public Vehicle Vehicle
        {
            get { return vehicle; }
            set { vehicle = value; }
        }

        public RelayCommand AddVehicleCommand { get; set; }


        public VehicleViewModel()
        {
            vehicle = new Vehicle("Vehicle  model name ");
            _color = Brushes.Red;
            PageName = "Vehicles";
            AddVehicleCommand = new RelayCommand(AddVehicle);
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

        void AddVehicle(object parameter)
        {
            User u = new User
            {
                Username = "fabio",
                Password = "lazzy"
            };

        }
    }

}
