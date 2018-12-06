using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TouristAgency.Models
{
    public class TourContext:DbContext
    {
        public TourContext() : base("TouristAgency") { }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}