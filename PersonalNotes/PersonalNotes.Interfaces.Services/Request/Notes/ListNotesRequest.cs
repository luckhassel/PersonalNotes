namespace PersonalNotes.Interfaces.Services.Request.Notes
{
    public class ListNotesRequest : IRequest
    {
        public DateTime? InitialDate { get; set; }
    }
}
