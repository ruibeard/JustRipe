using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustRipe.ViewModels
{
    public interface IBaseViewModel
    {
        /// <summary>
        /// Makes sure every child class has a page name. Usefull to show user te current Page
        /// </summary>
        string PageName { get; set; }
    }
}
