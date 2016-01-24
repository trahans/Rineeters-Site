using System;
using Rinita.Stephan.Models;
using Rinita.Stephan.Statics;
using Rinita.Stephan.Wrappers;
using static System.String;

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
            if (!IsValid(rsvp)) return Constants.ErrorMessage;
            
            rsvp.Email = rsvp.Email.ToLower();

            try
            {
                _entityWrapper.AddRsvpItem(rsvp);
            }
            catch (Exception)
            {
                return Constants.ErrorMessage;
            }

            return Constants.SuccessMessage;
        }

        public bool IsValid(RSVP rsvp)
        {
            return rsvp != null &&
                   !IsNullOrWhiteSpace(rsvp.Name) &&
                   !IsNullOrWhiteSpace(rsvp.Email);
        }
    }
}