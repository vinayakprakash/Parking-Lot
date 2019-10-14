using System.Collections.Generic;
using ParkingLot.Domain.Model.ParkingLog;
using ParkingLot.Domain.Repository;

namespace ParkingLot.Domain.Loaders
{
    public class VehicleLogLoader:IVehicleLogLoader
    {
        private readonly IVehicleLogRepository _vehicleLogRepository;

        public VehicleLogLoader(IVehicleLogRepository vehicleLogRepository)
        {
            _vehicleLogRepository = vehicleLogRepository;
        }

        public List<VehicleLog> Load()
        {
            return _vehicleLogRepository.Get();
        }
    }
}