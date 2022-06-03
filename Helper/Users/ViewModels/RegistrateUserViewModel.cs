using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper.Users.ViewModels
{
    public class RegistrateUserViewModel : UserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public RegistrateUserViewModel(string login, string password) : base(login, password)
        {
            Login = login;
            Password = password;
        }

        public RegistrateUserViewModel() : base() { }
    }
}
