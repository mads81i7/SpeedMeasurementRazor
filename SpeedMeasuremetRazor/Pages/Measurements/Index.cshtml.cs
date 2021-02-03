using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedMeasuremetRazor.Interfaces;

namespace SpeedMeasuremetRazor.Pages.Measurements
{
    public class IndexModel : PageModel
    {
        public ISpeedMeasurementRepo SpeedMeasurementRepo { get; set; }

        public IndexModel(ISpeedMeasurementRepo speedMeasurementRepo)
        {
            SpeedMeasurementRepo = speedMeasurementRepo;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SpeedMeasurementRepo.DeleteSpeedMeasurement((int)id);
            return Page();
        }
    }
}
