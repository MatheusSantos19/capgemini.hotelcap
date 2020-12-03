using HotelTDD.Domain;
using HotelTDD.Domain.Interface;
using HotelTDD.Infra.Context;
using HotelTDD.Repository.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTDD.Repository
{
    public class UserRepository : RepositoryCore,IUserRepository
    {
        public UserRepository(HotelContext hotelContext) : base(hotelContext)
        {

        }

        public void Create(Users user)
        {
            _hotelContext.User.Add(user);
            _hotelContext.SaveChanges();
        }

        public Users Login(string email, string password)
        {
            return _hotelContext.User.AsNoTracking().Where(e => e.Email == email && e.Password == password).FirstOrDefault();
        }
    }
}
