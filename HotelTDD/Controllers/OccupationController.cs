using HotelTDD.Services.Interface;
using HotelTDD.Services.Occupation.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HotelTDD.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class OccupationController : ControllerBase
    {
        private readonly IOccupationService _occupationService;

        public OccupationController(IOccupationService occupationService)
        {
            _occupationService = occupationService;
        }

        [HttpPost]
        [Authorize(Roles = "ADM,USR")]
        public IActionResult Create([FromBody] OccupationCreateRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Ocupação inválida.");

                _occupationService.Create(request);

                return Created(string.Empty, "Ocupação criada com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possivel salvar a ocupação: {ex}");
            }
        }
    }
}
