using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using ParkingLot.Domain.Model.Configuration;
using ParkingLot.Domain.Repository;
using ParkingLot.Infra.Configuration;
using ParkingLot.Infra.Dto;
using ParkingLot.Infra.Mappers;

namespace ParkingLot.Infra.Repository
{
    public class PricingModelRepository:IPricingModelRepository
    {
        private readonly IAppConfiguration _config;
        private readonly IPricingModelMapper _pricingModelMapper;

        public PricingModelRepository(IAppConfiguration config, IPricingModelMapper pricingModelMapper)
        {
            _config = config;
            _pricingModelMapper = pricingModelMapper;
        }

        public List<PricingModelAssociation> Get()
        {
            using (var conn = new SQLiteConnection(_config.GetConnectionString()))
            {
                conn.Open();
                const string parkingLotQuery = "SELECT id, name FROM t_parking_lot";
                var parkingLot = conn.Query<ParkingLotCategoryRow>(parkingLotQuery);

                const string vehicleTypeQuery = "SELECT id, type, max_weight FROM t_vehicle_type";
                var vehicleType = conn.Query<VehicleTypeRow>(vehicleTypeQuery);

                const string pricingTypeQuery = "SELECT id, type, min_hour, max_hour FROM t_pricing_type";
                var pricingType = conn.Query<PricingTypeRow>(pricingTypeQuery);

                const string pricingModelQuery =
                    "SELECT id, model_name, pricing_type_id, vehicle_type_id, price FROM t_pricing_model";
                var pricingModel = conn.Query<PricingModelRow>(pricingModelQuery);

                const string pricingAssociationQuery =
                    "SELECT lot_id, pricing_model_id FROM t_pricing_model_association";
                var pricingAssociation = conn.Query<PricingModelAssociationRow>(pricingAssociationQuery);

                return _pricingModelMapper.Map(parkingLot.ToList(), vehicleType.ToList(), pricingType.ToList(), pricingModel.ToList(),
                    pricingAssociation.ToList());
            }
        }

    }
}
