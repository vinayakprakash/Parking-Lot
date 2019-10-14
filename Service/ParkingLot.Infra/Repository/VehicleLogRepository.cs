using ParkingLot.Domain.Model.ParkingLog;
using ParkingLot.Domain.Repository;
using System.Collections.Generic;
using System.Data.SQLite;
using Dapper;
using ParkingLot.Infra.Configuration;
using ParkingLot.Infra.Dto;
using ParkingLot.Infra.Mappers;

namespace ParkingLot.Infra.Repository
{
    public class VehicleLogRepository : IVehicleLogRepository
    {
        private readonly IAppConfiguration _config;
        private readonly IVehicleLogMapper _vehicleLogMapper;

        public VehicleLogRepository(IAppConfiguration config, IVehicleLogMapper vehicleLogMapper)
        {
            _config = config;
            _vehicleLogMapper = vehicleLogMapper;
        }

        public List<VehicleLog> Get()
        {
            using (var conn = new SQLiteConnection(_config.GetConnectionString()))
            {
                conn.Open();
                const string vehicleLogQuery =
                    "SELECT id, lot_id, vehicle_type_id, vehicle_no, in_time, out_time,amount, weight FROM t_vehicle_log";
                var vehicleLog = conn.Query<VehicleLogRow>(vehicleLogQuery);

                const string parkingLotQuery = "SELECT id, name FROM t_parking_lot";
                var parkingLot = conn.Query<ParkingLotCategoryRow>(parkingLotQuery);

                const string vehicleTypeQuery = "SELECT id, type, max_weight FROM t_vehicle_type";
                var vehicleType = conn.Query<VehicleTypeRow>(vehicleTypeQuery);

                return _vehicleLogMapper.Map(vehicleLog, parkingLot, vehicleType);
            }
        }

        public void Save(VehicleLog vehicleLog)
        {
            using (var conn = new SQLiteConnection(_config.GetConnectionString()))
            {
                conn.Open();
                conn.Execute(@"INSERT INTO t_vehicle_log (lot_id, vehicle_type_id, vehicle_no, in_time, out_time,amount, weight)
                     VALUES (@lot_id, @vehicle_type_id, @vehicle_no, @in_time, @out_time,@amount, @weight)",
                    vehicleLog);
            }
        }

        public void Update(VehicleLog vehicleLog)
        {
            using (var conn = new SQLiteConnection(_config.GetConnectionString()))
            {
                conn.Open();
                conn.Execute(@"UPDATE t_vehicle_log SET lot_id=@lot_id, vehicle_type_id=@vehicle_type_id, vehicle_no=@vehicle_no, in_time=@in_time, out_time=@out_time,amount=@amount, weight=@weight)
                     WHERE id = @id",
                    vehicleLog);
            }
        }
    }
}