namespace ParkingLot.Domain.Model.Configuration
{
    public class PricingModel
    {
        public string Name { get; set; }

        public string PricingType { get; set; }

        public string VehicleType { get; set; }

        public int MinHour { get; set; }

        public int MaxHour { get; set; }

        public double Price { get; set; }
    }
}
