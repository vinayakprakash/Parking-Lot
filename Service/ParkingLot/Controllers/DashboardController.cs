using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ParkingLot.Domain.Loaders;
using ParkingLot.Domain.Model.Overview;

namespace ParkingLotApi.Controllers
{
    [Route("api/parkinglot/dashboard")]
    [ApiController]
    [Filters.Authorization]
    [AllowAnonymous]
    [EnableCors("MyPolicy")]
    public class DashboardController : ControllerBase
    {
        private readonly IParkingLotOverviewLoader _parkingLotOverviewLoader;

        public DashboardController(IParkingLotOverviewLoader parkingLotOverviewLoader)
        {
            _parkingLotOverviewLoader = parkingLotOverviewLoader;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ParkingLotOverview>> Get()
        {
            return Ok(_parkingLotOverviewLoader.Load());
        }
    }
}
