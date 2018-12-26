
using System.ComponentModel.DataAnnotations;
namespace TouristAgency.Models
{
    public class CreateTourModel
    {
        [Required]
        public Tour Tour { get; set; }
        [Required]
        public string Country { get; set; }
    }
}