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
            container= new Container("Container  model name ");
            _color = Brushes.Red;
            PageName = "Containers";
            AddContainerCommand = new RelayCommand(AddContainer);
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

        void AddContainer(object parameter)
        {
            User u = new User
            {
                Username = "fabio",
                Password = "lazzy"
            };

        }
    }

}
