using JustRipe.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustRipe.ViewModels
{
    class ViewModelMain : ViewModelBase
    {

        public Dispatch AddUserCommand { get; set; }

        public ViewModelMain()
        {

        }
    }
}
