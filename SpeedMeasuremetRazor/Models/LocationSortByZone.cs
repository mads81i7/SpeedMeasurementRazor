using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeedMeasuremetRazor.Models
{
    public class LocationSortByZone: IComparer<Location>
    {
        public int Compare(Location loc1, Location loc2)
        {
            if (loc1.Zone == loc2.Zone)
            {
                return 0;
            }
            return (loc1.Zone > loc2.Zone) ? 1 : -1;
        }
    }
}
