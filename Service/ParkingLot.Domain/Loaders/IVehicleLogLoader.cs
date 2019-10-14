using System.Collections.Generic;
using ParkingLot.Domain.Model.ParkingLog;

namespace ParkingLot.Domain.Loaders
{
    public interface IVehicleLogLoader
    {
        List<VehicleLog> Load();
    }
}