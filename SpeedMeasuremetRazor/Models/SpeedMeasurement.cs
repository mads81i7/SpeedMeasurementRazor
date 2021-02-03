using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeedMeasuremetRazor.Models
{
    public class SpeedMeasurement
    {
       public int Id { get; set; }
       public DateTime TimeStamp { get; set; }
       public int Speed { get; set; }
       public Location Location { get; set; }
       public string Image { get; set; }
    }
}
