using System.Collections.Generic;
using System.Web.Http;
using Rinita.Stephan.Models;
using System.Web.Http.Cors;

namespace Rinita.Stephan.Controllers
{
    [EnableCors(origins:"*", headers:"*",methods:"*")]
	public class RSVPController : ApiController
	{
		// GET api/<controller>
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<controller>/5
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<controller>
		public string Post([FromBody] RSVP rsvp)
		{
			// TODO: validate and write rsvp to database
			// TODO: return message response
			return "hello";
		}

		// PUT api/<controller>/5
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<controller>/5
		public void Delete(int id)
		{
		}
	}
}
