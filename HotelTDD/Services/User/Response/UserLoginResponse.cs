using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelTDD.Services.User.Response
{
    public class UserLoginResponse
    {
        public UserLoginResponse(string message, int status) {
            Message = message;
            Status = status;
        
        }

        public UserLoginResponse() { 
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public int Status { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }

    }
}
