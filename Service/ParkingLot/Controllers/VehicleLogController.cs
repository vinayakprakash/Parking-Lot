using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ParkingLot.Domain.Model.ParkingLog;
using ParkingLotApi.Service;

namespace ParkingLotApi.Controllers
{
    [Route("api/parkinglot/vehiclelog")]
    [ApiController]
    [Filters.Authorization]
    [AllowAnonymous]
    [EnableCors("MyPolicy")]
    public class VehicleLogController : ControllerBase
    {
        private readonly IVehicleLogService _vehicleLogService;

        public VehicleLogController(IVehicleLogService vehicleLogService)
        {
            _vehicleLogService = vehicleLogService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<VehicleLog>> GetVehicleLog()
        {
            return Ok(_vehicleLogService.Get());
        }

        [HttpPut]
        public ActionResult ModifyVehicleLog(VehicleLog vehicleLog)
        {
            _vehicleLogService.Update(vehicleLog);
            return Ok();
        }

        [HttpPost]
        public ActionResult AddVehicleLog(object vehicleLog)
        {
            //_vehicleLogService.Insert(vehicleLog);
            return Ok();
        }
    }
}