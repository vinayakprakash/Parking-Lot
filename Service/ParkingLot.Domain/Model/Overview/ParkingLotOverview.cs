using System.Collections.Generic;

namespace ParkingLot.Domain.Model.Overview
{
    public class ParkingLotOverview
    {
        public string ParkingLotName { get; set; }
        public List<VehicleType> VehicleType { get; set; }
    }
}
