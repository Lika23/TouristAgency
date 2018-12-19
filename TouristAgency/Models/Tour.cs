using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TouristAgency.Models
{
    public class Tour
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        public int Night { get; set; }
        public float Price { get; set; }
        public string City { get; set; }
        public string Hotel { get; set; }
        public string Url { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
    public class AllTours
    {
        public List<Tour> _tours { get; set; }
    }
}