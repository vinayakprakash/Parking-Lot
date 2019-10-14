using System.Collections.Generic;

namespace ParkingLot.Domain.Model.Configuration
{
    public class PricingModelAssociation
    {
        public string ParkingLotName { get; set; }

        public List<PricingModel> PricingModel { get; set; }
    }
}