using HotelTDD.Services.User.Request;
using HotelTDD.Services.User.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTDD.Services.Interface
{
    public interface IUserService
    {
        void Create(UserCreateRequest request);
        UserLoginResponse Login(string email, string password);
    }
}
