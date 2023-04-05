using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitOWork;
using WebApi.Helpers;

namespace WebApi.Controllers
{
    [Route("api/schedule")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ScheduleController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("GetAll")]
        public IActionResult GelAll()
        {
            Respuesta objRespuesta = new Respuesta();
            var lstSchedules = _unitOfWork.Shedule.GetAllShedules();
            objRespuesta.Exito = 1;
            objRespuesta.Data = lstSchedules;
            objRespuesta.StateCode = StatusCodes.Status200OK;

            return Ok(objRespuesta);
        }
        [HttpGet]
        [Route("GetById/{id:int}")]
        public IActionResult GetById(int id)
        {
            Respuesta objRespuesta = new Respuesta();
            var schedule = _unitOfWork.Shedule.GetSheduleById(id);
            if (schedule == null)
            {
                objRespuesta.Exito = 0;
                objRespuesta.Mensaje = "Not found register.";
                objRespuesta.StateCode = StatusCodes.Status404NotFound;
                return BadRequest(objRespuesta);
            }

            objRespuesta.Exito = 1;
            objRespuesta.Mensaje = "Found Register.";
            objRespuesta.StateCode = StatusCodes.Status200OK;
            objRespuesta.Data = schedule;

            return Ok(objRespuesta);
        }

        [HttpPost]
        [Route("Insert")]
        public IActionResult Insert([FromBody] Schedules schedule)
        {
            Respuesta objRespuesta = new Respuesta();
            if (!ModelState.IsValid)
            {
                objRespuesta.Exito = 0;
                objRespuesta.Mensaje = "Error created Driver";
                objRespuesta.StateCode = StatusCodes.Status400BadRequest;
                return BadRequest(objRespuesta);
            }

            int idnew = _unitOfWork.Shedule.AddSchedules(schedule.Week_Num,schedule.Start,schedule.Ends,schedule.Active,schedule.Route_Id);
            objRespuesta.Exito = 1;
            objRespuesta.Mensaje = "Register store";
            objRespuesta.Data = idnew;
            objRespuesta.StateCode = StatusCodes.Status201Created;
            return Ok(objRespuesta);
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] Schedules schedule)
        {
            Respuesta objRespuesta = new Respuesta();
            if (ModelState.IsValid && _unitOfWork.Shedule.UpdateShedules(schedule.Week_Num,schedule.Start,schedule.Ends,schedule.Active,schedule.Route_Id,schedule.Id))
            {
                objRespuesta.Exito = 1;
                objRespuesta.Mensaje = "Register store";
                objRespuesta.Data = schedule;
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
        public IActionResult Delete([FromBody] Schedules schedule)
        {
            Respuesta objRespuesta = new Respuesta();
            if (schedule.Id > 0)
            {
                objRespuesta.Exito = 1;
                objRespuesta.Mensaje = "Register deleted.";
                objRespuesta.Data = _unitOfWork.Shedule.Delete(schedule);
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
