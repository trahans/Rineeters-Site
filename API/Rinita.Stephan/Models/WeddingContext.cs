using System.Data.Entity;

namespace Rinita.Stephan.Models
{
    public class WeddingContext:DbContext
    {
        public DbSet<RSVP> Rsvps { get; set; }
    }
}