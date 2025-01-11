namespace SignalRWebUI.Dtos.ContactDtos
{
	public class CreateContactDto
	{
		public string Location { get; set; }
		public string City { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string FooterTitle { get; set; }
		public string FooterDescription { get; set; }
		public string OpenDays { get; set; }
		public string OpenHours { get; set; }
	}
}
