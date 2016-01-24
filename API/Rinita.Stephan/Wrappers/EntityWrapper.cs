using System.Collections.Generic;
using System.Linq;
using Rinita.Stephan.Models;

namespace Rinita.Stephan.Wrappers
{
    public class EntityWrapper : IEntityWrapper
    {
        public void AddRsvpItem(RSVP rsvp)
        {
            using (var context = new WeddingContext())
            {
                context.Rsvps.Add(rsvp);
                context.SaveChanges();
            }
        }

        public IEnumerable<RSVP> GetAllRsvps()
        {
            using (var context = new WeddingContext())
            {
                return context.Rsvps.ToList();
            }
        }
    }
}