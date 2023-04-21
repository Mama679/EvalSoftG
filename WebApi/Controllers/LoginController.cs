using Microsoft.AspNetCore.Mvc;
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
        private ITokenProvider _tokenProvider;
       

        public LoginController(IUnitOfWork unitOfWork, ITokenProvider tokenProvider)
        {
            _unitOfWork = unitOfWork;
            _tokenProvider = tokenProvider;          
        }    

         [HttpPost]
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
         }
    }
}
