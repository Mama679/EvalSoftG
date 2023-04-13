using Entities;
using Microsoft.AspNetCore.Mvc;
using UnitOWork;
using WebApi.Helpers;

namespace WebApi.Controllers
{
    [Route("api/driver")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DriverController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GelAll()
        {
            Respuesta objRespuesta = new Respuesta();
            var lstDrivers = _unitOfWork.Driver.GetList().ToList();
            
            objRespuesta.Exito = 1;
            objRespuesta.Data = lstDrivers;
            objRespuesta.StateCode = StatusCodes.Status200OK;

            return Ok(objRespuesta);
        }

        [HttpGet]
        [Route("GetById/{id:int}")]
        public IActionResult GetById(int id) 
        {
            Respuesta objRespuesta = new Respuesta();
            var driver = _unitOfWork.Driver.GetById(id);
            if(driver == null)
            {
                objRespuesta.Exito = 0;
                objRespuesta.Mensaje = "Not found register.";
                objRespuesta.StateCode = StatusCodes.Status404NotFound;
                return BadRequest(objRespuesta);
            }

            objRespuesta.Exito = 1;
            objRespuesta.Mensaje = "Found Register.";
            objRespuesta.StateCode = StatusCodes.Status200OK;
            objRespuesta.Data = driver;

            return Ok(objRespuesta);
        }

        [HttpPost]
        [Route("Insert")]
        public IActionResult Insert([FromBody] Drivers driver)
        {
            Respuesta objRespuesta = new Respuesta();
            if (!ModelState.IsValid)
            {
                objRespuesta.Exito = 0;
                objRespuesta.Mensaje = "Error created Driver";
                objRespuesta.StateCode = StatusCodes.Status400BadRequest;
                return BadRequest(objRespuesta);
            }

            int idnew = _unitOfWork.Driver.Insert(driver);
            objRespuesta.Exito = 1;
            objRespuesta.Mensaje = "Register store";
            objRespuesta.Data = idnew;
            objRespuesta.StateCode = StatusCodes.Status201Created;
            return Ok(objRespuesta);
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] Drivers driver)
        {
            Respuesta objRespuesta = new Respuesta();
            if (ModelState.IsValid && _unitOfWork.Driver.Update(driver))
            {
                objRespuesta.Exito = 1;
                objRespuesta.Mensaje = "Register store";
                objRespuesta.Data = driver;
                objRespuesta.StateCode = StatusCodes.Status201Created;
                return Ok(objRespuesta);
            }
            objRespuesta.Exito = 0;
            objRespuesta.Mensaje = "Error updated Driver";
            objRespuesta.StateCode = StatusCodes.Status400BadRequest;
            return BadRequest(objRespuesta);        
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public IActionResult Delete(int id)
        {
            Respuesta objRespuesta = new Respuesta();
            var driver = _unitOfWork.Driver.GetById(id);
            if (driver == null)
            {
                objRespuesta.Exito = 0;
                objRespuesta.Mensaje = "Not found register.";
                objRespuesta.StateCode = StatusCodes.Status404NotFound;
                return BadRequest(objRespuesta);
            }

            driver.Active = false;             
            objRespuesta.Exito = 1;
            objRespuesta.Mensaje = "Register deleted.";
            objRespuesta.Data = _unitOfWork.Driver.delDriver(driver.Id,driver.Active);
            objRespuesta.StateCode = StatusCodes.Status200OK;
            return Ok(objRespuesta);           
        }
    }
}
