using JustRipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace JustRipe.ViewModels
{
    public class UserViewModel : ObservableObject, IBaseViewModel
    {

        public UserViewModel()
        {
            user = new User();
            _color = Brushes.Green;
            PageName = "User";
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

        private User user;

        public User User
        {
            get { return user; }
            set { user = value; }
        }
    }
}
