using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustRipe.Models
{
    public class Vehicle
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string _year;
        public string Year
        {
            get { return _year; }
            set { _year = value; }
        }

        private string _type;
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private string _brand;
        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }

        private string _model;
        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }

        private string _capacity;
        public string Capacity
        {
            get { return _capacity; }
            set { _capacity = value; }
        }

        private string _licencePlate;
        public string LicencePlate
        {
            get { return _licencePlate; }
            set { _licencePlate = value; }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }
    }
}
