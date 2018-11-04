using JustRipe.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustRipe.ViewModels
{
    class CropViewModel : BaseViewModel
    {
        public ObservableCollection<Crop> Crop { get; set; }

        public CropViewModel()
        {
            Crop = new ObservableCollection<Crop>
            {
                new Crop { Name="Tom"},
            };

        }

    }

}
