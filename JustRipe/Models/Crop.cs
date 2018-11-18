using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustRipe.Models
{
    public class Crop : ObservableObject
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string _stage;

        public string Stage
        {
            get { return _stage; }
            set { _stage = value; }
        }

        private string _type;

        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }
        private string _area;

        public string Area
        {
            get { return _area; }
            set { _area = value; }
        }

    }
}