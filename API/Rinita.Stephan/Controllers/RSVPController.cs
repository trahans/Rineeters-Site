using System.Collections.Generic;
using System.Web.Http;
using Rinita.Stephan.Models;
using System.Linq;
using System.Web.Http.Cors;
using Rinita.Stephan.Helpers;

namespace Rinita.Stephan.Controllers
{
    [EnableCors(origins: "http://rinita-stephan.com,http://www.rinita-stephan.com", headers:"*", methods:"*")]
	public class RSVPController : ApiController
	{
        private readonly IPostHelper _postHelper;
        private readonly IGetHelper _getHelper;

        public RSVPController(IPostHelper postHelper, IGetHelper getHelper)
        {
            _postHelper = postHelper;
            _getHelper = getHelper;
        }

        // GET api/<controller>
		//public IEnumerable<RSVP> Get()
		//{
		//    return _getHelper.GetAllRsvps();
		//}

		// POST api/<controller>
		public string Post([FromBody] RSVP rsvp)
		{
		    return _postHelper.AddRsvp(rsvp);
		}
	}
}
