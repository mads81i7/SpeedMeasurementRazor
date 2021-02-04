using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SpeedMeasuremetRazor.Helpers;
using SpeedMeasuremetRazor.Interfaces;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Services
{
    

    public class LocationRepo: ILocationRepo 
    {
        private List<Location> LocationList { get; }

        public LocationRepo()
        {
            LocationList = MockData.Locations;
        }
        public List<Location> GetAllLocations()
        {
            return LocationList;
        }

        public void AddLocation(Location location)
        {
            LocationList.Add(location);
        }

        public void UpdateLocation(Location location)
        {
            for (int i = 0; i < LocationList.Count; i++)
            {
                if (location.Id == LocationList[i].Id)
                {
                    LocationList[i] = location;
                    break;
                }
            }
        }

        public Location GetLocation(int id)
        {
            foreach (var l in LocationList)
            {
                if (id == l.Id)
                {
                    return l;
                }
            }

            return null;
        }

        public void DeleteLocation(int id)
        {
            LocationList.Remove(GetLocation(id));
        }

        public int GetHighestLocationId()
        {
            int maxId = 0;

            foreach (Location location in LocationList)
            {
                if (location.Id > maxId)
                    maxId = location.Id;
            }

            return maxId;
        }
    }
}
