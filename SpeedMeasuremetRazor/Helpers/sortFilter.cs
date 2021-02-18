using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeedMeasuremetRazor.Helpers
{
    public class SortFilter
    {
        private Predicate<string> textpcomparer = (string str) => { 
            return if(str.Contains(
        
        
        public List<T> ComparerText<T>(List<T> objs)
        {
            return Comparer(objs, comparer);
        }

        public List<T> Comparer<T>(List<T> objs, string str)
        {
            Predicate<T> comparer = (string str) => { };
            List<T> newObj = new List<T>();
            foreach (var obj in objs.FindAll(comparer))
            {
                newObj.Add(obj)
            }
            return newObj;
        }
    }
}
