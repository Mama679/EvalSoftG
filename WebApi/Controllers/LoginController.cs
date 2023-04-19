using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UnitOWork;
using WebApi.Authentication;
using WebApi.Helpers;

namespace WebApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
       // private ITokenProvider _tokenProvider;
        private IConfiguration _configuration;

        public LoginController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            //_tokenProvider = tokenProvider;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult GetToken([FromBody] VMUser user)
        {
            string clave = Encript.GetSHA256(user.Password);
            var usuario = _unitOfWork.User.Authenticate(user.NomUser, clave);
            Respuesta respuesta = new Respuesta();
            if (usuario == null)
            {
                respuesta.Exito = 0;
                respuesta.Mensaje = "Invalid credentials";
                respuesta.StateCode = StatusCodes.Status401Unauthorized;
                return BadRequest(respuesta);
            }
            //create claims details based on the user information
            var claims = new[] {
                 new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Sub,_configuration["Jwt:Subject"]),
                 new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                 new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                 new Claim("UserId", usuario.Id.ToString()),
                 new Claim("DisplayName", usuario.Names),
                 new Claim("UserName", usuario.UserLogin)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

            respuesta.Exito = 1;
            respuesta.Mensaje = "User Registered";
            respuesta.StateCode = StatusCodes.Status202Accepted;
            respuesta.Data = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(respuesta);
        }

       /* [HttpPost]
        [Route("login")]
        public IActionResult GetToken([FromBody] VMUser userLogin)
        {
            string clave = Encript.GetSHA256(userLogin.Password);
            var user = _unitOfWork.User.Authenticate(userLogin.NomUser, clave);
            Respuesta respuesta = new Respuesta();
            if (user == null)
            {
                respuesta.Exito = 0;
                respuesta.Mensaje = "Token Invalid";
                respuesta.StateCode = StatusCodes.Status401Unauthorized;
                return BadRequest(respuesta);
            }
            var token = new JsonWebtoken
            {
                Access_Token = _tokenProvider.createToken(user, DateTime.UtcNow.AddHours(1)),
                Expires_in = 60 //Minutos
            };

            respuesta.Exito = 1;
            respuesta.Mensaje = "User Registred";
            respuesta.StateCode = StatusCodes.Status202Accepted;
            respuesta.Data = token;
            return Ok(respuesta);
        }*/
    }
}
