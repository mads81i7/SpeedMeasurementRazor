using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeedMeasuremetRazor.Helpers
{
    public class SortFilter
    {
        public static List<T> Comparer<T>(List<T> objs, Predicate<T> predicate)
        {
            return objs.FindAll(predicate);
        }
    }
}
