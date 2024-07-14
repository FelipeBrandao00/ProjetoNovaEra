using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TokenController : ControllerBase {

    private readonly IConfiguration _configuration;


    public TokenController(IConfiguration configuration) {
        _configuration = configuration;
    }

  
}
