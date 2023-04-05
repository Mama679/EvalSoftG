using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitOWork;
using WebApi.Helpers;

namespace WebApi.Controllers
{
    [Route("api/vehicle")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public VehicleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GelAll()
        {
            Respuesta objRespuesta = new Respuesta();
            var lstVehicles = _unitOfWork.Vehicle.GetList().ToList();

            objRespuesta.Exito = 1;
            objRespuesta.Data = lstVehicles;
            objRespuesta.StateCode = StatusCodes.Status200OK;

            return Ok(objRespuesta);
        }

        [HttpGet]
        [Route("GetById/{id:int}")]
        public IActionResult GetById(int id)
        {
            Respuesta objRespuesta = new Respuesta();
            var vehicle = _unitOfWork.Vehicle.GetById(id);
            if (vehicle == null)
            {
                objRespuesta.Exito = 0;
                objRespuesta.Mensaje = "Not found register.";
                objRespuesta.StateCode = StatusCodes.Status404NotFound;
                return BadRequest(objRespuesta);
            }

            objRespuesta.Exito = 1;
            objRespuesta.Mensaje = "Found Register.";
            objRespuesta.StateCode = StatusCodes.Status200OK;
            objRespuesta.Data = vehicle;

            return Ok(objRespuesta);
        }

        [HttpPost]
        [Route("Insert")]
        public IActionResult Insert([FromBody] Vehicles vehicle)
        {
            Respuesta objRespuesta = new Respuesta();
            if (!ModelState.IsValid)
            {
                objRespuesta.Exito = 0;
                objRespuesta.Mensaje = "Error created Driver";
                objRespuesta.StateCode = StatusCodes.Status400BadRequest;
                return BadRequest(objRespuesta);
            }

            int idnew = _unitOfWork.Vehicle.Insert(vehicle);
            objRespuesta.Exito = 1;
            objRespuesta.Mensaje = "Register store";
            objRespuesta.Data = idnew;
            objRespuesta.StateCode = StatusCodes.Status201Created;
            return Ok(objRespuesta);
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] Vehicles vehicle)
        {
            Respuesta objRespuesta = new Respuesta();
            if (ModelState.IsValid && _unitOfWork.Vehicle.Update(vehicle))
            {
                objRespuesta.Exito = 1;
                objRespuesta.Mensaje = "Register store";
                objRespuesta.Data = vehicle;
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
        public IActionResult Delete([FromBody] Vehicles vehicle)
        {
            Respuesta objRespuesta = new Respuesta();
            if (vehicle.Id > 0)
            {
                objRespuesta.Exito = 1;
                objRespuesta.Mensaje = "Register deleted.";
                objRespuesta.Data = _unitOfWork.Vehicle.Delete(vehicle);
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
