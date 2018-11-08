using JustRipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace JustRipe.ViewModels
{
    public class HarvestViewModel : ObservableObject, IBaseViewModel
    {
        public HarvestViewModel()
        {
            harvest = new Harvest("Harvesting PopCorn, I know");
            _color = Brushes.Brown;
            PageName = "Harvests page";
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

        private Harvest harvest;

        public Harvest Harvest
        {
            get { return harvest; }
            set { harvest = value; }
        }

    }
}
