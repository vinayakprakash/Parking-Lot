namespace ParkingLot.Infra.Dto
{
    public class PricingModelRow
    {
        public int id { get; set; }
        public string model_name { get; set; }
        public int pricing_type_id { get; set; }
        public int vehicle_type_id { get; set; }
        public double price { get; set; }
    }
}