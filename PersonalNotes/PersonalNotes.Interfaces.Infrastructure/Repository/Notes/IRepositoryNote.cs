using PersonalNotes.Entities.Notes;

namespace PersonalNotes.Interfaces.Infrastructure.Repository.Notes
{
    public interface IRepositoryNote
    {
        void CreateNote(Note note);
        Note? GetNote(Guid id, Guid userId);
        List<Note> ListNotes(Guid userId, DateTime? initialDate);
        void Save();
    }
}
