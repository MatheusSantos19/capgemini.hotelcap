using HotelTDD.Services.Interface;
using HotelTDD.Services.Room.Request;
using HotelTDD.Services.Room.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace HotelTDD.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpPost]
        [Authorize(Roles = "ADM,USR")]
        public IActionResult Create([FromBody] RoomCreateRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Quarto inválido.");

                _roomService.Create(request);

                return Created(string.Empty, "Quarto criado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possivel salvar o quarto: {ex}" );
            }
        }

        [HttpPatch]
        [Authorize(Roles = "ADM,USR")]
        public IActionResult Update([FromBody] RoomUpdateRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Situação inválida.");

                _roomService.Update(request);

                return Ok("Quarto atualizado com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possivel atualizar o quarto: {ex}");
            }
        }

        [HttpGet]
        [Authorize(Roles = "ADM,USR")]
        public IActionResult GetById([FromQuery] int roomId)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Id inválido.");

                RoomListResponse response = _roomService.GetById(roomId);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound($"Não foi possivel encontrar o quarto: {ex}");
            }
        }

        [HttpGet]
        [Authorize(Roles = "ADM,USR")]
        public IActionResult GetByTypeRoomId([FromQuery] int typeRoomId)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Id inválido.");

                IEnumerable<RoomListResponse> response = _roomService.GetByTypeRoomId(typeRoomId);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest($"Não foi possivel encontrar os quartos: {ex}");
            }
        }

    }
}
