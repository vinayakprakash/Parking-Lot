using System.Collections.Generic;
using ParkingLot.Domain.Model.Overview;
using ParkingLot.Infra.Dto;
using ParkingLot.Infra.Repository;

namespace ParkingLot.Infra.Mappers
{
    public interface IParkingLotOverviewMapper
    {
        List<ParkingLotOverview> Map(List<ParkingLotCategoryRow> parkingLots,
            List<VehicleTypeRow> vehicleType, List<PricingTypeRow> pricingType,
            List<CapacityRow> parkingCapacities, List<PricingModelRow> pricingModel,
            List<PricingModelAssociationRow> pricingAssociation, List<VehicleLogRow> vehicleLogs);
    }
}