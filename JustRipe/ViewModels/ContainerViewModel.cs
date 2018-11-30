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
    public class ContainerViewModel : ObservableObject
    {

        private Container container;

        public Container Container
        {
            get { return container; }
            set { container= value; }
        }

        public RelayCommand AddContainerCommand { get; set; }


        public ContainerViewModel()
        {
            PageName = "Containers";
            AddContainerCommand = new RelayCommand(AddContainer);
        }
        private string pageName;

        public string PageName
        {
            get { return pageName; }
            set { pageName = value; }
        }

        void AddContainer(object parameter)
        {
 
        }
    }

}
