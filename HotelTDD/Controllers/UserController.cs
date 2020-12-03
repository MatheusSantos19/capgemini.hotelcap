using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelTDD.Services.Interface;
using HotelTDD.Services.User.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelTDD.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {

        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Authorize(Roles = "ADM")]
        public IActionResult Create([FromBody] UserCreateRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Usuario inválido.");

                _userService.Create(request);

                return Created(string.Empty, "Usuário criado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possivel salvar o usuário: {ex}");
            }
        }
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(string email, string password)
        {
            return Ok( new ObjectResult(_userService.Login(email, password))) ;
        }


    }
}
