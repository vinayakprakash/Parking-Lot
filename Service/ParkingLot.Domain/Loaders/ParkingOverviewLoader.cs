using System.Collections.Generic;
using ParkingLot.Domain.Model.Overview;
using ParkingLot.Domain.Repository;

namespace ParkingLot.Domain.Loaders
{
    public class ParkingLotOverviewLoader: IParkingLotOverviewLoader
    {
        private readonly IParkingLotOverviewRepository _parkingLotOverviewRepository;

        public ParkingLotOverviewLoader(IParkingLotOverviewRepository parkingLotOverviewRepository)
        {
            _parkingLotOverviewRepository = parkingLotOverviewRepository;
        }

        public List<ParkingLotOverview> Load()
        {
            return _parkingLotOverviewRepository.Get();
        }
    }

}
