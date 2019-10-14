using System;

namespace ParkingLot.Infra.Dto
{
    public class VehicleLogRow
    {
        public int id { get; set; }
        public int lot_id { get; set; }
        public int vehicle_type_id { get; set; }
        public string vehicle_no { get; set; }
        public DateTime? in_time { get; set; }
        public DateTime? out_time { get; set; }
        public double amount { get; set; }
        public double weight { get; set; }
    }
}