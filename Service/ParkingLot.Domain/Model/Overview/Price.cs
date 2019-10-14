namespace ParkingLot.Domain.Model.Overview
{
    public class Price
    {
        public string Type { get; set; }
        public int MinHour { get; set; }
        public int MaxHour { get; set; }
        public double Amount { get; set; }
    }
}