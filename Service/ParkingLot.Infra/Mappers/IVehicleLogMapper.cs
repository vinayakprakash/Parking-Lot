using System.Collections.Generic;
using System.Text;
using ParkingLot.Domain.Model.ParkingLog;
using ParkingLot.Infra.Dto;

namespace ParkingLot.Infra.Mappers
{
    public interface IVehicleLogMapper
    {
        List<VehicleLog> Map(IEnumerable<VehicleLogRow> vehicleLog,
            IEnumerable<ParkingLotCategoryRow> parkingLot, IEnumerable<VehicleTypeRow> vehicleType);
    }
}