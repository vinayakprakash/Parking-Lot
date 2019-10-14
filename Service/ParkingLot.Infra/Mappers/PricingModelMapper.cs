using System.Collections.Generic;
using System.Linq;
using ParkingLot.Domain.Model.Configuration;
using ParkingLot.Infra.Dto;
using ParkingLot.Infra.Repository;

namespace ParkingLot.Infra.Mappers
{
    public class PricingModelMapper : IPricingModelMapper
    {
        public List<PricingModelAssociation> Map(List<ParkingLotCategoryRow> parkingLotCategory,
            List<VehicleTypeRow> vehicleTypeRows, List<PricingTypeRow> pricingTypeRows,
            List<PricingModelRow> pricingModelRows, List<PricingModelAssociationRow> pricingModelAssociationRows)
        {
            var vehicleTypeMap = vehicleTypeRows.ToDictionary(x => x.id, x => x.type);
            var pricingTypeMap = pricingTypeRows.ToDictionary(x => x.id,
                x => new PricingTypeDetails {type = x.type, min_hour = x.min_hour, max_hour = x.max_hour});

            var pricingAssociations = new List<PricingModelAssociation>();
            foreach (var parkingLot in parkingLotCategory)
            {
                var pricingModelAssociation = new PricingModelAssociation()
                {
                    ParkingLotName = parkingLot.name
                };
                var pricingModels = new List<PricingModel>();
                foreach (var pricingModelAssociationRow in pricingModelAssociationRows.Where(x =>
                    x.lot_id == parkingLot.id))
                {
                    foreach (var pricingModel in pricingModelRows.Where(x =>
                        x.id == pricingModelAssociationRow.pricing_model_id))
                    {
                        pricingModels.Add(new PricingModel()
                        {
                            Name = pricingModel.model_name,
                            VehicleType = vehicleTypeMap[pricingModel.vehicle_type_id],
                            PricingType = pricingTypeMap[pricingModel.pricing_type_id].type,
                            MinHour = pricingTypeMap[pricingModel.pricing_type_id].min_hour,
                            MaxHour = pricingTypeMap[pricingModel.pricing_type_id].max_hour,
                            Price = pricingModel.price
                        });
                    }
                }

                pricingModelAssociation.PricingModel = pricingModels;
                pricingAssociations.Add(pricingModelAssociation);
            }

            return pricingAssociations;
        }
    }
}