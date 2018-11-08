﻿using JustRipe.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustRipe.ViewModels
{
    class DashBoardViewModel : ObservableObject, IBaseViewModel
    {




        private string pageName;

        public string PageName
        {
            get { return pageName; }
            set { pageName = value; }
        }

    }

}
