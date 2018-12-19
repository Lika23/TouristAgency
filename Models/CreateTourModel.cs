using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TouristAgency.Models
{
    public class CreateTourModel
    {

        public Tour Tour { get; set; }
        [Required(ErrorMessage = "Error")]
        public string Country { get; set; }
    }
}