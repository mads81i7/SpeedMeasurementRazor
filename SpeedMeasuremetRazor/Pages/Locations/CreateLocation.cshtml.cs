using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedMeasuremetRazor.Interfaces;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Pages.Locations
{
    public class CreateLocationModel : PageModel
    {
        private ILocationRepo _locations;
        public List<Location> Locations { get; set; }

        [BindProperty] 
        public Location Location { get; set; }

        public CreateLocationModel(ILocationRepo repo)
        {
            _locations = repo;
        }

        public void OnGet()
        {
            Locations = _locations.GetAllLocations();
        }

        public IActionResult OnPost()
        {
            Location.Id = _locations.GetAllLocations().Count + 1;
            _locations.AddLocation(Location);
            Locations = _locations.GetAllLocations();
            return RedirectToPage("index");
        }
    }
}
