using System;

namespace ParkingLot.Domain.Model.ParkingLog
{
    public class VehicleLog
    {
        public int Id { get; set; }
        public string ParkingLotName { get; set; }
        public int ParkingLotId { get; set; }
        public string VehicleType { get; set; }
        public int VehicleTypeId { get; set; }
        public string VehicleRegistrationNumber { get; set; }
        public double Weight { get; set; }
        public DateTime InTime { get; set; }
        public DateTime? OutTime { get; set; }
        public double AmountReceived { get; set; }
    }
}
