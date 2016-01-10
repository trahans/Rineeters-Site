using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rinita_stephan.Models
{
    public class RSVP
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public bool RSVPed { get; set; }
        public int NumberOfGuests { get; set; }
        public string Comment { get; set; }
    }
}