using System.Collections.Generic;

namespace ParkingLot.Domain.Model.Overview
{
    public class VehicleType
    {
        public string Type { get; set; }
        public Capacity Capacity { get; set; }
        public List<Price> Prices { get; set; }
    }
}