using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using SpeedMeasuremetRazor.Interfaces;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Pages.Locations
{
    public class IndexModel : PageModel
    {
        public ILocationRepo LocationRepo { get; set; }

        public List<Location> SortableLocationList;
        
        public IndexModel(ILocationRepo repositoryLocation)
        {
            LocationRepo = repositoryLocation;

            SortableLocationList = LocationRepo.GetAllLocations();
        }

        public void OnGet()
        {
        }

        public IActionResult OnPostSort(int option, string option2)
        {
            if (option2.Length > 0)
            {
               // SortFilter.
            }

            if (option == 1)
            {
                SortableLocationList.Sort();
            }
            else if (option == 2)
            {
                SortableLocationList.Sort(new LocationSortByZone());
            }
            else if (option == 3)
            {
                SortableLocationList.Sort(new LocationSortBySpeed());
            }

            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LocationRepo.DeleteLocation((int)id);
            return Page();
        }
    }
}
