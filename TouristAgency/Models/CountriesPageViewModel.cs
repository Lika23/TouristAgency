using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TouristAgency.Models
{
    public class CountriesPageViewModel
    {
        public Country CurrentCountry { get; set; }
        public List<Country> Countries { get; set; }
    }
}