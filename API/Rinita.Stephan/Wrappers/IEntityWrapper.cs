using System.Collections.Generic;
using Rinita.Stephan.Models;

namespace Rinita.Stephan.Wrappers
{
    public interface IEntityWrapper
    {
        void AddRsvpItem(RSVP rsvp);

        IEnumerable<RSVP> GetAllRsvps();
    }
}
