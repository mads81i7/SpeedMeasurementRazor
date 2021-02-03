using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Helpers
{
    public class MockData
    {
        private static List<Location> _locations;

        public static List<Location> Locations
        {
            get
            {
                return new List<Location>()
                {
                    new Location()
                    {
                        Id = 1,
                        Address = "Maglegårdsvej 2",
                        Zone = Zone.By,
                        SpeedLimit = 50
                    },
                    new Location()
                    {
                        Id = 2,
                        Address = "Frederiksborgvej 120",
                        Zone = Zone.Motortrafikvej,
                        SpeedLimit = 90
                    },
                    new Location()
                    {
                        Id = 3,
                        Address = "Hillerødmotorvej 519",
                        Zone = Zone.By,
                        SpeedLimit = 130
                    }
                };
            }

        }

        private static List<SpeedMeasurement> _measurements;

        public static List<SpeedMeasurement> Measurements
        {
            get
            {
                List<SpeedMeasurement> measurements = new List<SpeedMeasurement>()
                {
                    new SpeedMeasurement()
                    {
                        Id = 1,
                        TimeStamp = DateTime.Now,
                        Speed = 50,
                        Location = Locations[0],
                        Image = RandomImage
                    },
                    new SpeedMeasurement()
                    {
                        Id = 2,
                        TimeStamp = DateTime.Now,
                        Speed = 80, 
                        Location = Locations[1], 
                        Image = RandomImage
                    },
                    new SpeedMeasurement()
                    {
                        Id = 3,
                        TimeStamp = DateTime.Now,
                        Speed = 130, 
                        Location = Locations[2],
                        Image = RandomImage
                    }
                };
                return measurements;
            }
        }

        private static List<string> _images = new List<string>()
        {
            "c1.jfif", "greycar.jfif", "nissan.jfif", "olsenbanden.jfif", "veteran.jfif", "whitecar.jfif",
            "whitetruck.jfif"
        };

        public static List<string> Images
        {
            get { return _images; }
        }

        private static Random r = new Random(DateTime.Now.Millisecond);
        public static string RandomImage
        {
            get
            {
                return _images[r.Next(0, _images.Count)];
            }
        }

        public static int RandomSpeed
        {
            get
            {
                return r.Next(-20, 375);
            }
        }




    }
}
