using PersonalNotes.Entities.Notes;
using PersonalNotes.Infraestructure.Data.Context;
using PersonalNotes.Interfaces.Infrastructure.Repository.Notes;

namespace PersonalNotes.Infrastructure.Data.Repository.Notes
{
    public class RepositoryNote : IRepositoryNote
    {
        private readonly PersonalNotesContext _context;
        public RepositoryNote(PersonalNotesContext context)
        {
            _context = context;
        }
        public void CreateNote(Note note)
        {
            _context.Notes.Add(note);
        }

        public Note? GetNote(Guid id, Guid userId)
        {
            return _context.Notes.FirstOrDefault(x => x.Id == id && x.UserId == userId);
        }

        public List<Note> ListNotes(Guid userId, DateTime? initialDate)
        {
            var notes = _context.Notes.Where(note => note.UserId == userId);

            if (initialDate != null)
            {
                notes = notes.Where(note => note.EndDate > initialDate);
            }

            return notes.OrderBy(note => note.StartDate).ToList();
        }

        public void Save()
        {
            _context.SaveChangesAsync();
        }
    }
}
