using Application.Interfaces;
using Application.Requests.Certificado;
using Application.Requests.Conteudo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [Authorize(Roles = "Administrador,Professor")]
    [ApiController]
    public class CertificadoController(ICertificadoService _service) : ControllerBase {
            [HttpPost("api/[controller]")]
            public async Task<ActionResult> AddCertificado(AddCertificadoRequest request) {
                var result = await _service.AddCertificado(request);
                if (!result.IsSuccess) return BadRequest(result);
                return Ok(result);
            }    

            [HttpGet("api/[controller]/{id:int}")]
            public async Task<ActionResult> GetCertificadoById(int id) {
                var request = new GetCertificadoByIdRequest() { CdCertificado = id };
                var result = await _service.GetCertificadoById(request);
                if (!result.IsSuccess) return BadRequest(result);
                return Ok(result);
            }

            [HttpDelete("api/[controller]")]
            public async Task<ActionResult> DeleteCertificado([FromBody] DeleteCertificadoRequest request) {
                var result = await _service.DeleteCertificado(request);
                if (!result.IsSuccess) return BadRequest(result);
                return Ok(result);
            }
        }
    }

