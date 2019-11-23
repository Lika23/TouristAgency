
using System.ComponentModel.DataAnnotations;
namespace TouristAgency.Models
{
    public class BookedTour
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        [Required]
        [Display(Name ="ФИО") ]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Номер телефона")]
        public string Number { get; set; }
        public Tour Tour { get; set; }
    }
}