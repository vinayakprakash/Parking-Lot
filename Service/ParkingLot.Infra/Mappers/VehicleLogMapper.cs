using System;
using System.Collections.Generic;
using System.Linq;
using ParkingLot.Domain.Model.ParkingLog;
using ParkingLot.Infra.Dto;

namespace ParkingLot.Infra.Mappers
{
    public class VehicleLogMapper : IVehicleLogMapper
    {
        public List<VehicleLog> Map(IEnumerable<VehicleLogRow> vehicleLog,
            IEnumerable<ParkingLotCategoryRow> parkingLot, IEnumerable<VehicleTypeRow> vehicleType)
        {
            var vehicleTypeMap = vehicleType.ToDictionary(x => x.id, x => x.type);
            var parkingLotMap = parkingLot.ToDictionary(x => x.id, x => x.name);
            return vehicleLog.Select(vl => new VehicleLog()
                {
                    Id = vl.id,
                    ParkingLotId = vl.lot_id,
                    ParkingLotName = parkingLotMap[vl.id],
                    VehicleTypeId = vl.vehicle_type_id,
                    VehicleType = vehicleTypeMap[vl.vehicle_type_id],
                    Weight = vl.weight,
                    VehicleRegistrationNumber = vl.vehicle_no,
                    InTime = Convert.ToDateTime(vl.in_time),
                    OutTime = Convert.ToDateTime(vl.out_time),
                    AmountReceived = vl.amount
                })
                .ToList();
        }
    }
}