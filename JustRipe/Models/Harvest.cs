using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustRipe.Models
{
    public class Harvest
    {

        public Harvest(string _name)
        {
            Name = _name;
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private DateTime _harvestDate;

        public DateTime HarvestDate
        {
            get { return _harvestDate; }
            set { _harvestDate = value; }
        }
    }
}
