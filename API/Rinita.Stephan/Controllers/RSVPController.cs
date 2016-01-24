using System.Collections.Generic;
using System.Web.Http;
using Rinita.Stephan.Models;
using System.Linq;
using System.Web.Http.Cors;
using Rinita.Stephan.Helpers;

namespace Rinita.Stephan.Controllers
{
    [EnableCors(origins:"*", headers:"*",methods:"*")]
	public class RSVPController : ApiController
	{
        private readonly IPostHelper _postHelper;

	    public RSVPController()
	    {
		    
	    }

        public RSVPController(IPostHelper postHelper)
        {
            _postHelper = postHelper;
        }

        // GET api/<controller>
		public IEnumerable<RSVP> Get()
		{
            List<RSVP> rsvps;
            using (var context = new WeddingContext())
            {
                rsvps = context.Rsvps.ToList();
            }
			return rsvps;
		}

		// POST api/<controller>
		public string Post([FromBody] RSVP rsvp)
		{
		    return _postHelper.AddRsvp(rsvp);
		}
	}
}
