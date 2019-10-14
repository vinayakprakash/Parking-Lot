using System;
using ParkingLot.Domain.Calculator;
using ParkingLot.Domain.Model.ParkingLog;
using ParkingLot.Domain.Repository;

namespace ParkingLot.Domain.Savers
{
    public class VehicleLogSaver: IVehicleLogSaver
    {
        private readonly IVehicleLogRepository _vehicleLogRepository;
        private readonly IParkingChargesCalculator _parkingChargesCalculator;

        public VehicleLogSaver(IVehicleLogRepository vehicleLogRepository, IParkingChargesCalculator parkingChargesCalculator)
        {
            _vehicleLogRepository = vehicleLogRepository;
            _parkingChargesCalculator = parkingChargesCalculator;
        }

        public void Insert(VehicleLog vehicleLog)
        {
            if (vehicleLog.OutTime.HasValue)
            {
                vehicleLog.AmountReceived = _parkingChargesCalculator.Calculate(vehicleLog.InTime,
                    Convert.ToDateTime(vehicleLog.OutTime), vehicleLog.ParkingLotName, vehicleLog.VehicleType);
            }
            _vehicleLogRepository.Save(vehicleLog);
        }

        public void Update(VehicleLog vehicleLog)
        {
            if (vehicleLog.OutTime.HasValue)
            {
                vehicleLog.AmountReceived = _parkingChargesCalculator.Calculate(vehicleLog.InTime,
                    Convert.ToDateTime(vehicleLog.OutTime), vehicleLog.ParkingLotName, vehicleLog.VehicleType);
            }
            _vehicleLogRepository.Update(vehicleLog);
        }
    }
}
