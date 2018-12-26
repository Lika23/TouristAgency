
using System.Collections.Generic;
namespace TouristAgency.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Tour> Tours { get; set; }
        public List<Picture> Pictures { get; set; }
        public string History { get; set; }
        public string Attractions { get; set; }
        public string Leisure { get; set; }
        public string Tip { get; set; }
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