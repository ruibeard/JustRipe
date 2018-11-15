using JustRipe.Models;
using System.Windows.Media;

namespace JustRipe.ViewModels
{
    public class FertiliserViewModel : ObservableObject, IBaseViewModel
    {

        private Fertiliser fertiliser;

        public Fertiliser Fertiliser
        {
            get { return fertiliser; }
            set { fertiliser = value; }
        }

        public RelayCommand AddFertiliserCommand { get; set; }


        public FertiliserViewModel()
        {
            fertiliser = new Fertiliser("Fertiliser model name ");
            _color = Brushes.Red;
            PageName = "Fertilisers";
            AddFertiliserCommand = new RelayCommand(AddFertiliser);
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

        void AddFertiliser(object parameter)
        {
      

        }
    }

}
