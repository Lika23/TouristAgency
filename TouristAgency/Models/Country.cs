using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TouristAgency.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Tour> Tours { get; set; }
        public List<Picture> Pictures { get; set; }
        public string Description { get; set; }
        public string Climate { get; set; }
        public string Kitchen { get; set; }
        public string Geography { get; set; }
        public string Population { get; set; }
        public Country()
        {
            Tours = new List<Tour>();
            Pictures = new List<Picture>();
        }
    }
    public class AllCounties
    {
        public List<Country> _countries { get; set; }
    }
}