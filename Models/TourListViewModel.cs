using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TouristAgency.Models
{
    public class TourListViewModel
    {
        public IEnumerable<Tour> Tours { get; set; }
    }
}