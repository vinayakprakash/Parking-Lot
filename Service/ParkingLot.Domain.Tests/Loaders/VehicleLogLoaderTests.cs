using NSubstitute;
using NUnit.Framework;
using ParkingLot.Domain.Loaders;
using ParkingLot.Domain.Repository;

namespace ParkingLot.Domain.Tests.Loaders
{
    public class VehicleLogLoaderTests
    {
        [Test]
        public void Should_load_from_repository_vehicle_logs()
        {
            var vehicleLogRepository = Substitute.For<IVehicleLogRepository>();
            var vehicleLogLoader = new VehicleLogLoader(vehicleLogRepository);
            vehicleLogLoader.Load();
            vehicleLogRepository.Received(1).Get();
        }
    }
}