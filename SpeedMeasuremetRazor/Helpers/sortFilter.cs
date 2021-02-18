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
            List<T> newObj = new List<T>();

            foreach (var obj in objs.FindAll(predicate))
            {
                newObj.Add(obj);
            }

            return newObj;
        }
    }
}
