using System;
using System.Collections.Generic;
using System.Linq;
using ParkingLot.Domain.Model.Overview;
using ParkingLot.Infra.Dto;
using ParkingLot.Infra.Repository;

namespace ParkingLot.Infra.Mappers
{
    public class ParkingLotOverviewMapper: IParkingLotOverviewMapper
    {
        public List<ParkingLotOverview> Map(List<ParkingLotCategoryRow> parkingLots,
    List<VehicleTypeRow> vehicleType, List<PricingTypeRow> pricingType,
    List<CapacityRow> parkingCapacities, List<PricingModelRow> pricingModel,
    List<PricingModelAssociationRow> pricingAssociation, List<VehicleLogRow> vehicleLogs)
        {
            var vehicleTypeMap = vehicleType.ToDictionary(x => x.id, x => x.type);
            var pricingTypeMap = pricingType.ToDictionary(x => x.id,
                x => new PricingTypeDetails { type = x.type, min_hour = x.min_hour, max_hour = x.max_hour });
            var vehicleCount = GetVehicleCount(vehicleLogs, parkingLots);
            var parkingLotOverviews = new List<ParkingLotOverview>();
            foreach (var parkingLot in parkingLots)
            {
                var parkingLotOverview = new ParkingLotOverview()
                {
                    ParkingLotName = parkingLot.name,
                    VehicleType = new List<VehicleType>()
                };
                foreach (var parkingCapacity in parkingCapacities.Where(x => x.lot_id == parkingLot.id))
                {
                    int count = 0;
                    if (vehicleCount.ContainsKey(parkingLot.id) && vehicleCount[parkingLot.id].ContainsKey(parkingCapacity.vehicle_type_id))
                    {
                        count = vehicleCount[parkingLot.id][parkingCapacity.vehicle_type_id];
                    }
                    var vehicleTp = new VehicleType()
                    {
                        Type = vehicleTypeMap[parkingCapacity.vehicle_type_id],
                        Capacity = new Capacity()
                        { Total = parkingCapacity.capacity, Occupied = count, Remaining = parkingCapacity.capacity - count },
                        Prices = new List<Price>()
                    };
                    foreach (var pma in pricingAssociation.Where(x => x.lot_id == parkingLot.id))
                    {
                        foreach (var pm in pricingModel.Where(x =>
                            x.id == pma.pricing_model_id && x.vehicle_type_id == parkingCapacity.vehicle_type_id))
                        {
                            vehicleTp.Prices.Add(new Price()
                            {
                                Type = pricingTypeMap[pm.pricing_type_id].type,
                                MinHour = pricingTypeMap[pm.pricing_type_id].min_hour,
                                MaxHour = pricingTypeMap[pm.pricing_type_id].max_hour,
                                Amount = pm.price
                            });
                        }
                    }
                    parkingLotOverview.VehicleType.Add(vehicleTp);
                }
                parkingLotOverviews.Add(parkingLotOverview);
            }
            return parkingLotOverviews;
        }

        private Dictionary<int, Dictionary<int, int>> GetVehicleCount(List<VehicleLogRow> vehicleLogs,
            List<ParkingLotCategoryRow> parkingLots)
        {
            var vehicleCount = new Dictionary<int, Dictionary<int, int>>();
            foreach (var parkingLot in parkingLots)
            {
                foreach (var line in vehicleLogs.Where(x => x.lot_id == parkingLot.id && !x.out_time.HasValue)
                    .GroupBy(info => info.vehicle_type_id)
                    .Select(group => new
                    {
                        Metric = group.Key,
                        Count = group.Count()
                    }))
                {
                    vehicleCount.Add(parkingLot.id, new Dictionary<int, int>() { { line.Metric, line.Count } });
                    Console.WriteLine("{0} {1}", line.Metric, line.Count);
                }
            }

            return vehicleCount;
        }
    }
}
