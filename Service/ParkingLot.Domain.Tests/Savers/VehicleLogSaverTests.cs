using System;
using NSubstitute;
using NUnit.Framework;
using ParkingLot.Domain.Calculator;
using ParkingLot.Domain.Model.ParkingLog;
using ParkingLot.Domain.Repository;
using ParkingLot.Domain.Savers;

namespace ParkingLot.Domain.Tests.Savers
{
    public class VehicleLogSaverTests
    {
        [Test]
        public void Should_save_to_repository_vehicle_logs_without_calculating_price_when_no_out_time()
        {
            var vehicleLogRepository = Substitute.For<IVehicleLogRepository>();
            var parkingChargesCalculator = Substitute.For<IParkingChargesCalculator>();

            var vehicleLogSaver = new VehicleLogSaver(vehicleLogRepository, parkingChargesCalculator);
            vehicleLogSaver.Insert(new VehicleLog());
            vehicleLogRepository.ReceivedWithAnyArgs(1).Save(Arg.Any<VehicleLog>());
            parkingChargesCalculator.Received(0).Calculate(Arg.Any<DateTime>(), Arg.Any<DateTime>(), Arg.Any<string>(),
                Arg.Any<string>());
        }

        [Test]
        public void Should_save_to_repository_vehicle_logs_with_calculating_price_when_out()
        {
            var vehicleLogRepository = Substitute.For<IVehicleLogRepository>();
            var parkingChargesCalculator = Substitute.For<IParkingChargesCalculator>();

            var vehicleLogSaver = new VehicleLogSaver(vehicleLogRepository, parkingChargesCalculator);
            vehicleLogSaver.Insert(new VehicleLog(){OutTime = DateTime.Now});
            vehicleLogRepository.ReceivedWithAnyArgs(1).Save(Arg.Any<VehicleLog>());
            parkingChargesCalculator.Received(1).Calculate(Arg.Any<DateTime>(), Arg.Any<DateTime>(), Arg.Any<string>(),
                Arg.Any<string>());
        }

        [Test]
        public void Should_update_to_repository_vehicle_logs_without_calculating_price_when_no_out_time()
        {
            var vehicleLogRepository = Substitute.For<IVehicleLogRepository>();
            var parkingChargesCalculator = Substitute.For<IParkingChargesCalculator>();

            var vehicleLogSaver = new VehicleLogSaver(vehicleLogRepository, parkingChargesCalculator);
            vehicleLogSaver.Update(new VehicleLog());
            vehicleLogRepository.ReceivedWithAnyArgs(1).Update(Arg.Any<VehicleLog>());
            parkingChargesCalculator.Received(0).Calculate(Arg.Any<DateTime>(), Arg.Any<DateTime>(), Arg.Any<string>(),
                Arg.Any<string>());
        }

        [Test]
        public void Should_update_to_repository_vehicle_logs_with_calculating_price_when_out()
        {
            var vehicleLogRepository = Substitute.For<IVehicleLogRepository>();
            var parkingChargesCalculator = Substitute.For<IParkingChargesCalculator>();

            var vehicleLogSaver = new VehicleLogSaver(vehicleLogRepository, parkingChargesCalculator);
            vehicleLogSaver.Update(new VehicleLog() { OutTime = DateTime.Now });
            vehicleLogRepository.ReceivedWithAnyArgs(1).Update(Arg.Any<VehicleLog>());
            parkingChargesCalculator.Received(1).Calculate(Arg.Any<DateTime>(), Arg.Any<DateTime>(), Arg.Any<string>(),
                Arg.Any<string>());
        }

    }
}