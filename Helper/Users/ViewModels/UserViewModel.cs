using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Users.ViewModels
{
    public class UserViewModel 
    {
        public Guid Guid { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public UserViewModel(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public UserViewModel() { }
    }
}
