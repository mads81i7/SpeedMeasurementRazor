using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeedMeasuremetRazor.Models
{
    public class LocationSortBySpeed: IComparer<Location>
    {
        public int Compare(Location loc1, Location loc2)
        {
            if (loc1.SpeedLimit == loc2.SpeedLimit)
            {
                return 0;
            }
            return (loc1.SpeedLimit > loc2.SpeedLimit) ? 1 : -1;
        }
    }
}
