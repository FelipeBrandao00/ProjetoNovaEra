using Application.Interfaces;
using Application.Requests;
using Application.Requests.CargoUsuario;
using Application.Requests.PermissaoCargo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Authorize(Roles = "Administrador, Master, Professor")]
    public class PermissaoCargoController(IPermissaoCargoService permissaoCargoService) : ControllerBase
    {
        [HttpPost("api/[controller]")]
        public async Task<ActionResult> AddCPermissaoCargo(CreatePermissaoCargoRequest request)
        {
            var result = await permissaoCargoService.AddPermissaoCargo(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }
        [HttpDelete("api/[controller]")]
        public async Task<ActionResult> DeletePermissaoCargo(DeletePermissaoCargoRequest request)
        {
            var result = await permissaoCargoService.DeletePermissaoCargo(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }
        
        [HttpGet("api/[controller]")]
        public async Task<ActionResult> GetPermissoesByCargoId([FromQuery]int cdCargo,[FromQuery]int? pageNumber = null,[FromQuery]int? pageSize = null)
        {
            var request = new GetPermissoesByCargoIdRequest(cdCargo,pageNumber, pageSize);
            var result = await permissaoCargoService.GetPermissoesByCargoId(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("api/[controller]/AddCPermissoesCargo")]
        public async Task<ActionResult> AddCPermissoesCargo(AddPermissoesCargoRequest request) {
            var result = await permissaoCargoService.AddPermissoesCargo(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }
    }
}
