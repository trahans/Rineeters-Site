using System;
using System.Collections.Generic;
using System.Linq;
using Rinita.Stephan.Models;
using Rinita.Stephan.Wrappers;

namespace Rinita.Stephan.Helpers
{
    public class GetHelper : IGetHelper
    {
        private readonly IEntityWrapper _entityWrapper;

        public GetHelper(IEntityWrapper entityWrapper)
        {
            _entityWrapper = entityWrapper;
        }

        public IEnumerable<RSVP> GetAllRsvps()
        {
            try
            {
                var results = _entityWrapper.GetAllRsvps();
                return results == null ?
                    Enumerable.Empty<RSVP>() :
                    SortRsvps(results);
            }
            catch (Exception)
            {
                return Enumerable.Empty<RSVP>();
            }
        }

        private static IEnumerable<RSVP> SortRsvps(IEnumerable<RSVP> input)
        {
            return input.OrderByDescending(rsvp => rsvp.RSVPed);
        }
    }
}