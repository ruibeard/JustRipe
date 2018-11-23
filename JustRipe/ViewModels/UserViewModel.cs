using JustRipe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace JustRipe.ViewModels
{
    public class UserViewModel : ObservableObject
    {

        public UserViewModel()
        {
            user = new User();
        }
        
 
        private User user;

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public string Name { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string DateOfBirth { get; set; }

        public string Wage { get; set; }


    }
}
