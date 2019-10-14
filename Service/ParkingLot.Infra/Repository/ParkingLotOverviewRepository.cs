using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using Dapper;
using ParkingLot.Domain.Model.Overview;
using ParkingLot.Domain.Repository;
using ParkingLot.Infra.Configuration;
using ParkingLot.Infra.Dto;
using ParkingLot.Infra.Mappers;

namespace ParkingLot.Infra.Repository
{
    public class ParkingLotOverviewRepository : IParkingLotOverviewRepository
    {
        private readonly IAppConfiguration _config;
        private readonly IParkingLotOverviewMapper _parkingLotOverviewMapper;

        public ParkingLotOverviewRepository(IAppConfiguration config,
            IParkingLotOverviewMapper parkingLotOverviewMapper)
        {
            _config = config;
            _parkingLotOverviewMapper = parkingLotOverviewMapper;
        }

        public List<ParkingLotOverview> Get()
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

                const string pricingCapacityQuery = "SELECT id, vehicle_type_id, lot_id, capacity FROM t_capacity";
                var pricingCapacity = conn.Query<CapacityRow>(pricingCapacityQuery);

                const string pricingModelQuery =
                    "SELECT id, model_name, pricing_type_id, vehicle_type_id, price FROM t_pricing_model";
                var pricingModel = conn.Query<PricingModelRow>(pricingModelQuery);

                const string pricingAssociationQuery =
                    "SELECT lot_id, pricing_model_id FROM t_pricing_model_association";
                var pricingAssociation = conn.Query<PricingModelAssociationRow>(pricingAssociationQuery);

                const string vehicleLogQuery =
                    "SELECT id, lot_id, vehicle_type_id, vehicle_no, in_time, out_time,amount, weight FROM t_vehicle_log";
                var vehicleLog = conn.Query<VehicleLogRow>(vehicleLogQuery);


                return _parkingLotOverviewMapper.Map(parkingLot.ToList(), vehicleType.ToList(), pricingType.ToList(),
                    pricingCapacity.ToList(), pricingModel.ToList(),
                    pricingAssociation.ToList(), vehicleLog.ToList());
            }
        }
    }
}