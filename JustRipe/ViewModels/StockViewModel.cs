using JustRipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace JustRipe.ViewModels
{
    public class StockViewModel : ObservableObject, IBaseViewModel
    {

        public StockViewModel()
        {
            stock = new Stock("Amazing Product in stock model");
            _color = Brushes.Green;
            PageName = "Stock";
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

        private Stock stock;

        public Stock Stock
        {
            get { return stock; }
            set { stock = value; }
        }
    }
}
