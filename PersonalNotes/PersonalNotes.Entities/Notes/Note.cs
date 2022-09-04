using PersonalNotes.Entities.Users;

namespace PersonalNotes.Entities.Notes
{
    public class Note
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public User User { get; set; }

        public static Note Create(DateTime startDate, DateTime endDate, string subject, string description, Guid userId)
        {
            Note note = new Note
            {
                Id = Guid.NewGuid(),
                UserId = userId
            };

            note.Update(startDate, endDate, subject, description);

            return note;

        }

        public void Update(DateTime startDate, DateTime endDate, string subject, string description)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Subject = subject;
            this.Description = description;
        }
    }
}
