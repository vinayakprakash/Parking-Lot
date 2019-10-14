using System.Collections.Generic;
using ParkingLot.Domain.Model.Overview;

namespace ParkingLot.Domain.Repository
{
    public interface IParkingLotOverviewRepository
    {
        List<ParkingLotOverview> Get();
    }
}
