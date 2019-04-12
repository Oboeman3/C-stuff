using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSearch
{
    public class User
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }


        public User(string name, string userName, string password, string email)
        {
            Name = name;
            UserName = userName;
            Password = password;
            Email = email;
        }
        public User()
        {

        }
    }
}
