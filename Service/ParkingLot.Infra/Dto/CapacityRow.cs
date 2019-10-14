namespace ParkingLot.Infra.Dto
{
    public class CapacityRow
    {
        public int id { get; set; }
        public int vehicle_type_id { get; set; }
        public int lot_id { get; set; }
        public int capacity { get; set; }
    }
}