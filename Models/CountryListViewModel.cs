using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TouristAgency.Models
{
    public class CountryListViewModel
    {
        public IEnumerable<Country> Countries { get; set; }
    }
}