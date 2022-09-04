namespace PersonalNotes.Interfaces.Services.Request.Notes
{
    public class CreateNotesRequest : IRequest
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
    }
}
