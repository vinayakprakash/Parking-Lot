using System;
using System.Collections.Generic;
using System.Text;
using ParkingLot.Domain.Model.Configuration;
using ParkingLot.Infra.Dto;
using ParkingLot.Infra.Repository;

namespace ParkingLot.Infra.Mappers
{
    public interface IPricingModelMapper
    {
        List<PricingModelAssociation> Map(List<ParkingLotCategoryRow> parkingLotCategory,
            List<VehicleTypeRow> vehicleTypeRows, List<PricingTypeRow> pricingTypeRows,
            List<PricingModelRow> pricingModelRows, List<PricingModelAssociationRow> pricingModelAssociationRows);
    }
}