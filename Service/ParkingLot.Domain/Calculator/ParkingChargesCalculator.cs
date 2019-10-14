using ParkingLot.Domain.Model.Configuration;
using ParkingLot.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot.Domain.Calculator
{
    public class ParkingChargesCalculator : IParkingChargesCalculator
    {
        private readonly IPricingModelRepository _pricingModelRepository;

        public ParkingChargesCalculator(IPricingModelRepository pricingModelRepository)
        {
            _pricingModelRepository = pricingModelRepository;
        }

        public double Calculate(DateTime inTime, DateTime outTime, string parkingLot, string vehicleType)
        {
            var hours = GetTime(inTime, outTime);
            var pricingModel = _pricingModelRepository.Get().First(x => x.ParkingLotName == parkingLot);
            var modelsForVehicle = pricingModel.PricingModel.Where(x => x.VehicleType == vehicleType);
            return GetPrice(hours, modelsForVehicle.ToList());
        }

        private double GetPrice(double hours, List<PricingModel> modelsForVehicle)
        {
            double price = 0D;
            foreach (var model in modelsForVehicle)
            {
                if (hours >= model.MinHour && hours < model.MaxHour)
                {
                    price = model.Price;
                    break;
                }
            }
            return Math.Abs(price) < 0.0001 ? 1000 : price;
        }

        private static double GetTime(DateTime inTime, DateTime outTime)
        {
            var diff = outTime - inTime;
            return diff.TotalHours;
        }
    }
}