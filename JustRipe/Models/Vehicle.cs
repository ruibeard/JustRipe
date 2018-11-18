using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustRipe.Models
{
    public class Vehicle : ObservableObject
    {
        public Vehicle(string _name)
        {
            Name = _name;
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string _model;

        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }


        private string _brand;

        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }
        private int _capacity;

        public int Capacity
        {
            get { return _capacity; }
            set { _capacity = value; }
        }

        private string _licensePlate;

        public string LicensePlate
        {
            get { return _licensePlate; }
            set { _licensePlate = value; }
        }

    }
}
