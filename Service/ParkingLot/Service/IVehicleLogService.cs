using System.Collections.Generic;
using ParkingLot.Domain.Model.ParkingLog;

namespace ParkingLotApi.Service
{
    public interface IVehicleLogService
    {
        List<VehicleLog> Get();

        void Update(VehicleLog vehicleLog);

        void Insert(VehicleLog vehicleLog);

    }
}