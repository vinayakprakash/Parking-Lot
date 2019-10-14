using System.Collections.Generic;
using ParkingLot.Domain.Loaders;
using ParkingLot.Domain.Model.ParkingLog;
using ParkingLot.Domain.Savers;

namespace ParkingLotApi.Service
{
    public class VehicleLogService : IVehicleLogService
    {
        private readonly IVehicleLogLoader _vehicleLogLoader;
        private readonly IVehicleLogSaver _vehicleLogSaver;

        public VehicleLogService(IVehicleLogLoader vehicleLogLoader, IVehicleLogSaver vehicleLogSaver)
        {
            _vehicleLogLoader = vehicleLogLoader;
            _vehicleLogSaver = vehicleLogSaver;
        }

        public List<VehicleLog> Get()
        {
            return _vehicleLogLoader.Load();
        }

        public void Update(VehicleLog vehicleLog)
        {
            _vehicleLogSaver.Update(vehicleLog);
        }

        public void Insert(VehicleLog vehicleLog)
        {
            _vehicleLogSaver.Insert(vehicleLog);

            throw new System.NotImplementedException();
        }
    }
}