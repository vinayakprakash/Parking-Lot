using ParkingLot.Domain.Model.ParkingLog;

namespace ParkingLot.Domain.Savers
{
    public interface IVehicleLogSaver
    {
        void Insert(VehicleLog vehicleLog);
        void Update(VehicleLog vehicleLog);
    }
}