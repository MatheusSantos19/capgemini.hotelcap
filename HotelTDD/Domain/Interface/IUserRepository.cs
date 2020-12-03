using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTDD.Domain.Interface
{
    public interface IUserRepository
    {
        void Create(Users user);
        Users Login(string email, string password);
    }
}
