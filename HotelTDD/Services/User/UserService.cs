using HotelTDD.Domain;
using HotelTDD.Domain.Interface;
using HotelTDD.Services.Interface;
using HotelTDD.Services.User.Request;
using HotelTDD.Services.User.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HotelTDD.Services.User
{
    public class UserService : IUserService
    {
        IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Create(UserCreateRequest request)
        {
            Users user = new Users(request.Name,request.Password,request.Email,request.Profile);
            _userRepository.Create(user);
        }

        public UserLoginResponse Login(string email, string password)
        {
            var user = _userRepository.Login(email, password);

            if (user.Id == 0)
                return new UserLoginResponse("Usuario ou senha inválido",StatusCodes.Status404NotFound);

            UserLoginResponse userLogin = new UserLoginResponse() {Id=user.Id,Name=user.Name,Email=user.Email,Role=user.Profile };
            userLogin.Token = GenerateToken(userLogin);

            userLogin.Status = StatusCodes.Status200OK;
            return userLogin;
        }

        private string GenerateToken(UserLoginResponse user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("fedaf7d8863b48e197b9287d492b708e");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString().Trim()),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
