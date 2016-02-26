namespace Rinita.Stephan.Models
{
	public class RSVP
	{
        public int ID { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public bool RSVPed { get; set; }
		public int NumberOfGuests { get; set; }
		public string Comment { get; set; }
	}
}