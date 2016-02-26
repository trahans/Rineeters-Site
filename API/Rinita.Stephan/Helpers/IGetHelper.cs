using System.Collections.Generic;
using Rinita.Stephan.Models;

namespace Rinita.Stephan.Helpers
{
    public interface IGetHelper
    {
        IEnumerable<RSVP> GetAllRsvps();
    }
}
