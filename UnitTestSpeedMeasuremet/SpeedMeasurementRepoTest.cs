using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpeedMeasuremetRazor.Exceptions;
using SpeedMeasuremetRazor.Interfaces;
using SpeedMeasuremetRazor.Models;
using SpeedMeasuremetRazor.Services;

namespace UnitTestSpeedMeasuremet
{
    [TestClass]
    public class SpeedMeasurementRepoTest
    {
        [TestMethod]
        [ExpectedException(typeof(CalibrationException))]
        public void AddSpeedMeasurementTest301()
        {
            //Arrange
            ISpeedMeasurementRepo speedRepo = new SpeedMeasurementRepo();

            //Act
            speedRepo.AddSpeedMeasurement(301, new Location(), "aaa");

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(CalibrationException))]
        public void AddSpeedMeasurementTest0()
        {
            //Arrange
            ISpeedMeasurementRepo speedRepo = new SpeedMeasurementRepo();

            //Act
            speedRepo.AddSpeedMeasurement(0, new Location(), "aaa");

            //Assert
        }

        [TestMethod]
        public void AddSpeedMeasurementTest1()
        {
            //Arrange
            ISpeedMeasurementRepo speedRepo = new SpeedMeasurementRepo();
            int expected = speedRepo.GetAllSpeedMeasurements().Count + 1;

            //Act
            speedRepo.AddSpeedMeasurement(1, new Location(), "aaa");

            //Assert
            Assert.AreEqual(expected, speedRepo.GetAllSpeedMeasurements().Count);
        }

        [TestMethod]
        public void AddSpeedMeasurementTest300()
        {
            //Arrange
            ISpeedMeasurementRepo speedRepo = new SpeedMeasurementRepo();
            int expected = speedRepo.GetAllSpeedMeasurements().Count + 1;

            //Act
            speedRepo.AddSpeedMeasurement(300, new Location(), "aaa");

            //Assert
            Assert.AreEqual(expected, speedRepo.GetAllSpeedMeasurements().Count);
        }
    }
}
