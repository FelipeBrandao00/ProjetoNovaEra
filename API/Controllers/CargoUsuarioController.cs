using Application.Interfaces;
using Application.Requests.CargoUsuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Authorize(Roles = "Administrador")]
    public class CargoUsuarioController(ICargoUsuarioService cargoUsuarioService) : ControllerBase
    {
        [HttpPost("api/[controller]")]
        public async Task<ActionResult> AddCargoUsuario(CreateCargoUsuarioRequest request)
        {
            var result = await cargoUsuarioService.AddCargoUsuario(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }
        [HttpDelete("api/[controller]")]
        public async Task<ActionResult> DeleteCargoUsuario(DeleteCargoUsuarioRequest request)
        {
            var result = await cargoUsuarioService.DeleteCargoUsuario(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }
        
        [HttpGet("api/[controller]")]
        public async Task<ActionResult> GetCargosByUserId([FromQuery]Guid cdUsuario,[FromQuery]int? pageNumber = null,[FromQuery]int? pageSize = null)
        {
            var request = new GetCargosByUserIdRequest(cdUsuario,pageNumber, pageSize);
            var result = await cargoUsuarioService.GetCargosByUserId(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }
    }
}
