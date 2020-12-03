using HotelTDD.Services.Client.Request;
using HotelTDD.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HotelTDD.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        [Authorize(Roles = "ADM,USR")]
        public IActionResult Create([FromBody] ClientCreateRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Cliente inválido.");

                _clientService.Create(request);

                return Created(string.Empty, "Cliente criado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possivel salvar o cliente: {ex}");
            }
        }

        [HttpGet]
        [Authorize(Roles = "ADM,USR")]
        public IActionResult GetById([FromQuery] int id)
        {
            try
            {
               var response = _clientService.GetById(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound($"Não foi possivel encontrar o cliente: {ex}");
            }
        }
    }
}
