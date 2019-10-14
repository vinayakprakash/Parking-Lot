using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using ParkingLot.Domain.Calculator;
using ParkingLot.Domain.Model.Configuration;
using ParkingLot.Domain.Repository;
using TechTalk.SpecFlow;

namespace ParkingLot.Domain.Tests.Calculator
{
    [Binding]
    public class ParkingChargesComputationSteps
    {
        private IParkingChargesCalculator _parkingChargesCalculator;
        private List<PricingModelAssociation> _pricingModel;
        private DateTime _inTime;
        private DateTime _outTime;
        private string _parkingLotType;
        private string _vehicleType;

        [Given(@"Following pricing model for (.*)")]
        public void GivenFollowingPricingModelForParkinglot(string parkingLotName, Table table)
        {
            var pricingModel = new List<PricingModel>();
            foreach (var row in table.Rows)
            {
                pricingModel.Add(new PricingModel
                {
                    Name = row["Name"],
                    VehicleType = row["VehicleType"],
                    MinHour = Convert.ToInt32(row["MinHour"]),
                    MaxHour = Convert.ToInt32(row["MaxHour"]),
                    PricingType = row["PricingType"],
                    Price = Convert.ToDouble(row["Price"])
                });
            }
            _pricingModel = new List<PricingModelAssociation>()
            {
                new PricingModelAssociation()
                {
                    ParkingLotName = parkingLotName,
                    PricingModel = pricingModel
                }
            };
        }
        
        [Given(@"the details of vehicle and timing")]
        public void GivenTheDetailsOfVehicleAndTiming(Table table)
        {
            _inTime = Convert.ToDateTime(table.Rows[0]["InTime"]);
            _outTime = Convert.ToDateTime(table.Rows[0]["OutTime"]);
            _vehicleType = table.Rows[0]["VehicleType"];
            _parkingLotType = "parkinglot1";
        }

        [When(@"parking amount computation is launched")]
        public void WhenParkingAmountComputationIsLaunched()
        {
            var pricingRespository = Substitute.For<IPricingModelRepository>();
            pricingRespository.Get().ReturnsForAnyArgs(_pricingModel);
            _parkingChargesCalculator = new ParkingChargesCalculator(pricingRespository);
        }
        
        [Then(@"following should be the price")]
        public void ThenFollowingShouldBeThePrice(Table table)
        {
            var expectedPrice = table.Rows[0][0];
            var actualPrice = _parkingChargesCalculator.Calculate(_inTime, _outTime, _parkingLotType, _vehicleType);
            Assert.That(Convert.ToDouble(expectedPrice),Is.EqualTo(actualPrice));
        }
    }
}
