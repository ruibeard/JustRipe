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
    public class LoginViewModel : ObservableObject, IBaseViewModel
    {


        public LoginViewModel()
        {
            PageName = "Harvests page";

        }
        private string pageName;

        public string PageName
        {
            get { return pageName; }
            set { pageName = value; }
        }
    }

}
