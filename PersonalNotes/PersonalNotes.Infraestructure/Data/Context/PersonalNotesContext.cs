using Microsoft.EntityFrameworkCore;
using PersonalNotes.Entities.Notes;
using PersonalNotes.Entities.Users;
using PersonalNotes.Infraestructure.Data.Config.Notes;
using PersonalNotes.Infraestructure.Data.Config.Users;

namespace PersonalNotes.Infraestructure.Data.Context
{
    public class PersonalNotesContext : DbContext
    {
        public PersonalNotesContext()
        {
        }

        public PersonalNotesContext(DbContextOptions<PersonalNotesContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            UserConfiguration.ConfigureUser(builder);
            NoteConfiguration.ConfigureNote(builder);
        }
    }
}
