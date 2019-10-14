namespace ParkingLot.Infra.Configuration
{
    public interface IAppConfiguration
    {
        string GetConnectionString();
    }
}