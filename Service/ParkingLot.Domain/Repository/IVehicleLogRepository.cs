using System.Collections.Generic;
using ParkingLot.Domain.Model.ParkingLog;

namespace ParkingLot.Domain.Repository
{
    public interface IVehicleLogRepository
    {
        List<VehicleLog> Get();

        void Save(VehicleLog vehicleLog) ;

        void Update(VehicleLog vehicleLog);
    }
}