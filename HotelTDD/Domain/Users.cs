using HotelTDD.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTDD.Domain
{
    public class Users : DomainBase
    {
        public Users(string name, string password, string email, string profile)
        {
            Name = name;
            Password = password;
            this.Email = email;
            this.Profile = profile;
        }

        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Profile { get; set; }

    }
}
