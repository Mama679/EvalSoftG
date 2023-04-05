using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitOWork;
using WebApi.Helpers;

namespace WebApi.Controllers
{
    [Route("api/route")]
    [ApiController]
    public class RouteController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public RouteController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GelAll()
        {
            Respuesta objRespuesta = new Respuesta();
            var lstRoutes = _unitOfWork.Route.GetAllRoutes();
            objRespuesta.Exito = 1;
            objRespuesta.Data = lstRoutes;
            objRespuesta.StateCode = StatusCodes.Status200OK;

            return Ok(objRespuesta);
        }

        [HttpGet]
        [Route("GetById/{id:int}")]
        public IActionResult GetById(int id)
        {
            Respuesta objRespuesta = new Respuesta();
            var route = _unitOfWork.Route.GetRouteById(id);
            if (route == null)
            {
                objRespuesta.Exito = 0;
                objRespuesta.Mensaje = "Not found register.";
                objRespuesta.StateCode = StatusCodes.Status404NotFound;
                return BadRequest(objRespuesta);
            }

            objRespuesta.Exito = 1;
            objRespuesta.Mensaje = "Found Register.";
            objRespuesta.StateCode = StatusCodes.Status200OK;
            objRespuesta.Data = route;

            return Ok(objRespuesta);
        }

        [HttpPost]
        [Route("Insert")]
        public IActionResult Insert([FromBody] Routes route)
        {
            Respuesta objRespuesta = new Respuesta();
            if (!ModelState.IsValid)
            {
                objRespuesta.Exito = 0;
                objRespuesta.Mensaje = "Error created Driver";
                objRespuesta.StateCode = StatusCodes.Status400BadRequest;
                return BadRequest(objRespuesta);
            }

            int idnew = _unitOfWork.Route.AddRoute(route.Description, route.Driver_Id, route.Vehicle_Id, route.Active);
            objRespuesta.Exito = 1;
            objRespuesta.Mensaje = "Register store";
            objRespuesta.Data = idnew;
            objRespuesta.StateCode = StatusCodes.Status201Created;
            return Ok(objRespuesta);
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] Routes route)
        {
            Respuesta objRespuesta = new Respuesta();
            if (ModelState.IsValid && _unitOfWork.Route.UpdateRoute(route.Description,route.Driver_Id,route.Vehicle_Id,route.Active,route.Id))
            {
                objRespuesta.Exito = 1;
                objRespuesta.Mensaje = "Register store";
                objRespuesta.Data = route;
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
        public IActionResult Delete([FromBody] Routes route)
        {
            Respuesta objRespuesta = new Respuesta();
            if (route.Id > 0)
            {
                objRespuesta.Exito = 1;
                objRespuesta.Mensaje = "Register deleted.";
                objRespuesta.Data = _unitOfWork.Route.Delete(route);
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
