﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustRipe.Models
{
    public class Container : ObservableObject
    {

        public Container(string _name)
        {
            Name = _name;
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}