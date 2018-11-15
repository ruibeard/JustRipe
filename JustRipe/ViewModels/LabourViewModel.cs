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
    public class LabourViewModel : ObservableObject, IBaseViewModel
    {

        private Labour labour;

        public Labour Labour
        {
            get { return labour; }
            set { labour = value; }
        }

        public RelayCommand AddLabourCommand { get; set; }


        public LabourViewModel()
        {
            labour = new Labour("Labour model name ");
            _color = Brushes.Red;
            PageName = "Labours";
            AddLabourCommand = new RelayCommand(AddLabour);
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

        void AddLabour(object parameter)
        {
            
        }
    }

}
