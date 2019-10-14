using System;

namespace ParkingLot.Domain.Calculator
{
    public interface IParkingChargesCalculator
    {
        double Calculate(DateTime inTime, DateTime outTime, string parkingLot, string vehicleType);
    }
}