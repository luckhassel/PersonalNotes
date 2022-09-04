namespace PersonalNotes.Interfaces.Services.Request.Notes
{
    public class GetNoteRequest : IRequest
    {
        public Guid Id { get; set; }
    }
}
