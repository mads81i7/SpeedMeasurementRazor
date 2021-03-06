using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SpeedMeasuremetRazor.Helpers;
using SpeedMeasuremetRazor.Interfaces;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Pages.Measurements
{
    public class CreateSpeedMeasurementModel : PageModel
    {
        private ISpeedMeasurementRepo _measurements;
        private ILocationRepo _locations;
        public List<SpeedMeasurement> Measurements { get; set; }
        public List<SelectListItem> Options { get; set; }

        [BindProperty]
        public int LocationId { get; set; }

        public string InvalidPost;
        public CreateSpeedMeasurementModel(ISpeedMeasurementRepo repo, ILocationRepo locationRepo)
        {
            _measurements = repo;
            _locations = locationRepo;
        }
        public void OnGet()
        {
            OnGetMeasurement();
        }
        public void OnGetMeasurement()
        {
            Measurements = _measurements.GetAllSpeedMeasurements();
            Options = _locations.GetAllLocations().Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Address
            }).ToList();
        }
        public  IActionResult OnPost()
        {
            Location l = _locations.GetLocation(LocationId);
            
            try
            {
                _measurements.AddSpeedMeasurement(MockData.RandomSpeed, _locations.GetLocation(LocationId), MockData.RandomImage);
            
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                InvalidPost = e.Message;
                OnGetMeasurement();
                return Page();
            }

            return RedirectToPage("Index");
        }
    }
}
