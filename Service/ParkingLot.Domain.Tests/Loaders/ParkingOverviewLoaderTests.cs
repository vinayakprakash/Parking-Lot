using NSubstitute;
using NUnit.Framework;
using ParkingLot.Domain.Loaders;
using ParkingLot.Domain.Repository;

namespace ParkingLot.Domain.Tests.Loaders
{
    public class ParkingOverviewLoaderTests
    {
        [Test]
        public void Should_load_from_repository_overview_of_parking_lot()
        {
            var parkingLotOverviewRepository = Substitute.For<IParkingLotOverviewRepository>();
            var parkingOverviewLoader = new ParkingLotOverviewLoader(parkingLotOverviewRepository);
            parkingOverviewLoader.Load();
            parkingLotOverviewRepository.Received(1).Get();
        }
    }
}
