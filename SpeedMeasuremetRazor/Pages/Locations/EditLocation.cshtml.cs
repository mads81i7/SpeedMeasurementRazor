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
    public class EditLocationModel : PageModel
    {
        private readonly ILocationRepo _locations;
        [BindProperty]
        public new Location Location { get; set; }

        public EditLocationModel(ILocationRepo locations)
        {
            _locations = locations;
        }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Location = _locations.GetLocation((int)id);

            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _locations.UpdateLocation(Location);
            return RedirectToPage("./Index");
        }
    }
}
