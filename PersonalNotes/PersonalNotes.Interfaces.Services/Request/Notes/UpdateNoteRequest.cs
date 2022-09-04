namespace PersonalNotes.Interfaces.Services.Request.Notes
{
    public class UpdateNoteRequest : CreateNotesRequest
    {
        public Guid Id { get; set; }
    }
}
