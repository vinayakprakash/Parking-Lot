namespace ParkingLot.Infra.Repository
{
    public class PricingTypeRow
    {
        public int id { get; set; }
        public string type { get; set; }
        public int min_hour { get; set; }
        public int max_hour { get; set; }
    }
}