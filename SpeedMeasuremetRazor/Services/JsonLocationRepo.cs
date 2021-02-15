using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpeedMeasuremetRazor.Helpers;
using SpeedMeasuremetRazor.Interfaces;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Services
{
    public class JsonLocationRepo: ILocationRepo
    {
        private string JsonFileName = @"Data\LocationData.json";
        public List<Location> GetAllLocations()
        {
            return JsonFileReader<Location>.ReadJson(JsonFileName);
        }

        public void AddLocation(Location location)
        {
            List<Location> locations = GetAllLocations();
            locations.Add(location);
            JsonFileWriter<Location>.WriteToJson(locations, JsonFileName);
        }

        public void UpdateLocation(Location location)
        {
            List<Location> LocationList = GetAllLocations();
            for (int i = 0; i < LocationList.Count; i++)
            {
                if (location.Id == LocationList[i].Id)
                {
                    LocationList[i] = location;
                    break;
                }
            }
            JsonFileWriter<Location>.WriteToJson(LocationList, JsonFileName);
        }

        public Location GetLocation(int id)
        {
            List<Location> LocationList = GetAllLocations().ToList();
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
            List<Location> LocationList = GetAllLocations();
            for (int i = 0; i < LocationList.Count; i++)
            {
                if (LocationList[i].Id == id)
                {
                    LocationList.Remove(LocationList[i]);
                    break;
                }
            }
            JsonFileWriter<Location>.WriteToJson(LocationList, JsonFileName);
        }

        public int GetHighestLocationId()
        {
            List<Location> LocationList = GetAllLocations();
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
