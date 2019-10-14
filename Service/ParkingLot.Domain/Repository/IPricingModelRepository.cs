using System.Collections.Generic;
using ParkingLot.Domain.Model.Configuration;

namespace ParkingLot.Domain.Repository
{
    public interface IPricingModelRepository
    {
        List<PricingModelAssociation> Get();
    }
}