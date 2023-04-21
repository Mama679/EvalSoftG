using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Security.Claims;
using UnitOWork;
using WebApi.Authentication;
using WebApi.Helpers;

namespace WebApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("getall")]
        [Authorize]
        public IActionResult GelAll()
        {
            //var identity = HttpContext.User.Identity as ClaimsIdentity;
            Respuesta objRespuesta = new Respuesta();
           // var stoken = JsonWebtoken.ValidarToken(identity);   
            var lstUsers = _unitOfWork.User.GetList().ToList();

            objRespuesta.Exito = 1;
            objRespuesta.Data = lstUsers;
            objRespuesta.StateCode = StatusCodes.Status200OK;

            return Ok(objRespuesta);
        }

        [HttpGet]
        [Route("GetById/{id:int}")]
        public IActionResult GetById(int id)
        {
            Respuesta objRespuesta = new Respuesta();
            var user = _unitOfWork.User.GetById(id);
            if (user == null)
            {
                objRespuesta.Exito = 0;
                objRespuesta.Mensaje = "Not found register.";
                objRespuesta.StateCode = StatusCodes.Status404NotFound;
                return BadRequest(objRespuesta);
            }

            objRespuesta.Exito = 1;
            objRespuesta.Mensaje = "Found Register.";
            objRespuesta.StateCode = StatusCodes.Status200OK;
            objRespuesta.Data = user;

            return Ok(objRespuesta);
        }

        [HttpPost]
        [Route("Insert")]
        public IActionResult Insert([FromBody] Users user)
        {
            Respuesta objRespuesta = new Respuesta();
            string clave = Encript.GetSHA256(user.Password);
            user.Password = clave;
            if (!ModelState.IsValid)
            {
                objRespuesta.Exito = 0;
                objRespuesta.Mensaje = "Error created Driver";
                objRespuesta.StateCode = StatusCodes.Status400BadRequest;
                return BadRequest(objRespuesta);
            }

            int idnew = _unitOfWork.User.Insert(user);
            objRespuesta.Exito = 1;
            objRespuesta.Mensaje = "Register store";
            objRespuesta.Data = idnew;
            objRespuesta.StateCode = StatusCodes.Status201Created;
            return Ok(objRespuesta);
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] Users user)
        {
            Respuesta objRespuesta = new Respuesta();
            string clave = Encript.GetSHA256(user.Password);
            user.Password = clave;
            if (ModelState.IsValid && _unitOfWork.User.Update(user))
            {
                objRespuesta.Exito = 1;
                objRespuesta.Mensaje = "Register store";
                objRespuesta.Data = user;
                objRespuesta.StateCode = StatusCodes.Status201Created;
                return Ok(objRespuesta);
            }
            objRespuesta.Exito = 0;
            objRespuesta.Mensaje = "Error updated Driver";
            objRespuesta.StateCode = StatusCodes.Status400BadRequest;
            return BadRequest(objRespuesta);
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete([FromBody] Users user)
        {
            Respuesta objRespuesta = new Respuesta();
            if (user.Id > 0)
            {
                objRespuesta.Exito = 1;
                objRespuesta.Mensaje = "Register deleted.";
                objRespuesta.Data = _unitOfWork.User.Delete(user);
                objRespuesta.StateCode = StatusCodes.Status200OK;
                return Ok(objRespuesta);
            }
            objRespuesta.Exito = 0;
            objRespuesta.Mensaje = "Error, Register no deleted.";
            objRespuesta.StateCode = StatusCodes.Status404NotFound;
            return BadRequest(objRespuesta);
        }
    }

}
