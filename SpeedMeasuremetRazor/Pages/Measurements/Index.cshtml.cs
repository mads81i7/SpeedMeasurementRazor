using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeedMeasuremetRazor.Helpers;
using SpeedMeasuremetRazor.Interfaces;
using SpeedMeasuremetRazor.Models;

namespace SpeedMeasuremetRazor.Pages.Measurements
{
    public class IndexModel : PageModel
    {
        public ISpeedMeasurementRepo SpeedMeasurementRepo { get; set; }
        public List<SpeedMeasurement> FilterList { get; set; }

        public IndexModel(ISpeedMeasurementRepo speedMeasurementRepo)
        {
            SpeedMeasurementRepo = speedMeasurementRepo;
            FilterList = SpeedMeasurementRepo.GetAllSpeedMeasurements();
        }

        public void OnGet()
        {
        }

        public IActionResult OnPostFilter(int option)
        {
            switch (option)
            {
                //case 1:
                //    break;
                case 2:
                    Predicate<SpeedMeasurement> predicateOver = (SpeedMeasurement s) => { return s.Speed > s.Location.SpeedLimit; };
                    FilterList = SortFilter.Comparer(FilterList, predicateOver);
                    break;
                case 3:
                    Predicate<SpeedMeasurement> predicateCut = s => { return s.Speed > s.Location.SpeedLimit * 1.3; };
                    FilterList = SortFilter.Comparer(FilterList, predicateCut);
                    break;
                case 4:
                    Predicate<SpeedMeasurement> predicateConditional = s =>
                    {
                        if (s.Location.Zone == Zone.Motorvej)
                        {
                            return s.Speed > s.Location.SpeedLimit * 1.3;
                        }
                        else
                        {
                            return s.Speed > s.Location.SpeedLimit * 1.6;
                        }
                    };
                    FilterList = SortFilter.Comparer(FilterList, predicateConditional);
                    break;
                case 5:
                    Predicate<SpeedMeasurement> predicateUnconditional = s =>
                    {
                        return s.Speed > s.Location.SpeedLimit * 2 && s.Speed >= 100;
                    };
                    FilterList = SortFilter.Comparer(FilterList, predicateUnconditional);
                    break;
                default:
                    break;
            }
            return Page();
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
