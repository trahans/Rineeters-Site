using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Rinita.Stephan.Models
{
    public class WeddingContext:DbContext
    {
        public WeddingContext()
            : base("Rinita.StephanDB")
        {

        }
        public DbSet<RSVP> RSVPs { get; set; }
    }
}