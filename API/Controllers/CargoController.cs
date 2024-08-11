using Application.Interfaces;
using Application.Requests.Cargos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize(Roles = "Admnistrador")]
    [ApiController]
    public class CargoController(ICargoService cargoService) : ControllerBase
    {
        [HttpGet("api/[controller]")]
        public async Task<ActionResult> GetCargos([FromQuery]int? pageNumber = null,[FromQuery]int? pageSize = null)
        {
            var request = new GetAllCargosRequest(pageNumber, pageSize);
            var result = await cargoService.GetCargos(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }
    }
}
