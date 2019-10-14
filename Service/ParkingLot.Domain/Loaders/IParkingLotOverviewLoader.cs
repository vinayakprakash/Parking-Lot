using System.Collections.Generic;
using ParkingLot.Domain.Model.Overview;

namespace ParkingLot.Domain.Loaders
{
    public interface IParkingLotOverviewLoader
    {
        List<ParkingLotOverview> Load();
    }
}