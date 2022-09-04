using Microsoft.EntityFrameworkCore;
using PersonalNotes.Entities.Notes;

namespace PersonalNotes.Infraestructure.Data.Config.Notes
{
    public static class NoteConfiguration
    {
        public static void ConfigureNote(ModelBuilder noteBuilder)
        {
            noteBuilder.Entity<Note>(n =>
            {
                n.ToTable("tblNote");
                n.HasKey(n => n.Id);
                n.Property(n => n.Id).HasColumnName("id");
                n.Property(n => n.StartDate).HasColumnName("start_date");
                n.Property(n => n.EndDate).HasColumnName("end_date");
                n.Property(n => n.Subject).HasColumnName("subject");
                n.Property(n => n.Description).HasColumnName("description");
                n.HasOne(n => n.User).WithMany(u => u.Notes).HasForeignKey(n => n.UserId);
                n.Property(n => n.UserId).HasColumnName("user_id");
            });
        }
    }
}
