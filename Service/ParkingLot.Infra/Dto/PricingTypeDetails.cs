namespace ParkingLot.Infra.Dto
{
    public class PricingTypeDetails
    {
        public string type { get; set; }
        public int min_hour { get; set; }
        public int max_hour { get; set; }
    }
}