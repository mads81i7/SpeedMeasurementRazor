using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpeedMeasuremetRazor.Models
{
    public class Location: IComparable<Location>
    {
        public static int staticInt { get; set; }
        public int Id { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Required(ErrorMessage = "SpeedLimit is required")]
        public int SpeedLimit { get; set; }
        public Zone Zone { get; set; }
        public int CompareTo(Location other)
        {
            return string.Compare(Address, other.Address);
        }
    }
}
