namespace ParkingLotApi.Service
{
    public interface ILoginService
    {
        string GetUserRole(string tokenId);
    }
}