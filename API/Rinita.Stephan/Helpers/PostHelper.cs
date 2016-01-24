using Rinita.Stephan.Models;
using Rinita.Stephan.Wrappers;

namespace Rinita.Stephan.Helpers
{
    public class PostHelper : IPostHelper
    {
        private readonly IEntityWrapper _entityWrapper;

        public PostHelper(IEntityWrapper entityWrapper)
        {
            _entityWrapper = entityWrapper;
        }

        public string AddRsvp(RSVP rsvp)
        {
            return "suck it";
        }
    }
}