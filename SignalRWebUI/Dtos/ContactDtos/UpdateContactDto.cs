namespace SignalRWebUI.Dtos.ContactDtos
{
	public class UpdateContactDto
	{
		public int ContactId { get; set; }
		public string Location { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string? FooterTitle { get; set; }
		public string FooterDescription { get; set; }
		public string OpenDays { get; set; }
		public string OpenHours { get; set; }
	}
}
