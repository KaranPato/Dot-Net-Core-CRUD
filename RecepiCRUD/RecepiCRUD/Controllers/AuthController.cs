using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecepiCRUD.Service.Interfaces;
using RecepiCRUD.ViewModel;

namespace RecepiCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AuthController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            if (model.Username == "admin" && model.Password == "admin")
            {
                var token = _tokenService.CreateToken(model.Username, "Admin");
                return Ok(new { token });
            }

            return Unauthorized("Invalid Credentials");
        }
    }
}
