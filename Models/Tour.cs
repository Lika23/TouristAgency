using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace TouristAgency.Models
{
    public class Tour
    {
        [HiddenInput(DisplayValue=false)]
        public int Id { get; set; }
        public List<Picture> Pictures { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [Required]
        public int Night { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Hotel { get; set; }
        [Required]
        public string Nutrition { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int CountryId { get; set; }
        
        public Country Country { get; set; }
        public Tour()
        {
            Pictures = new List<Picture>();
        }
    }

    public class AllTours
    {
        public List<Tour> _tours { get; set; }
    }
}