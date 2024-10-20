using Application.Interfaces;
using Application.Requests.CargoUsuario;
using Application.Requests.Frequencia;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [ApiController]
    [Authorize(Roles = "Administrador,Professor")]
    public class FrequenciaController(IFrequenciaService frequenciaService) : ControllerBase {
        [HttpPost("api/[controller]")]
        public async Task<ActionResult> AddFrequencia(AddFrequenciaRequest request) {
            var result = await frequenciaService.AddFrequencia(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }
        [HttpDelete("api/[controller]")]
        public async Task<ActionResult> DeleteFrequencia(DeleteFrequenciaRequest request) {
            var result = await frequenciaService.DeleteFrequencia(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }

        [HttpGet("api/[controller]")]
        public async Task<ActionResult> GetFrequenciasByAulaId([FromQuery] int cdAula, [FromQuery] int? pageNumber = null, [FromQuery] int? pageSize = null) {
            var request = new GetFrequenciasByAulaIdRequest(cdAula, pageNumber, pageSize);
            var result = await frequenciaService.GetFrequenciasByAulaId(request);
            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }
    }
}
