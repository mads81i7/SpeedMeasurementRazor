using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpeedMeasuremetRazor.Interfaces;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Services
{
    public class JsonSpeedMeasurementRepo: ISpeedMeasurementRepo
    {
        public List<SpeedMeasurement> GetAllSpeedMeasurements()
        {
            throw new NotImplementedException();
        }

        public void AddSpeedMeasurement(int speed, Location location, string imageName)
        {
            throw new NotImplementedException();
        }

        public double AvarageSpeed()
        {
            throw new NotImplementedException();
        }

        public int NoOfOverSpeedLimit()
        {
            throw new NotImplementedException();
        }

        public int NoOfCutInLicense()
        {
            throw new NotImplementedException();
        }

        public int NoOfCutInLicenseForeach()
        {
            throw new NotImplementedException();
        }

        public int NoOfConditionalRevocation()
        {
            throw new NotImplementedException();
        }

        public void DeleteSpeedMeasurement(int id)
        {
            throw new NotImplementedException();
        }
    }
}
