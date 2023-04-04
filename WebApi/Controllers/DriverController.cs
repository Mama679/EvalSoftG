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
    }
}
