using PersonalNotes.Entities.Notes;

namespace PersonalNotes.Entities.Users
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public List<Note> Notes { get; set; }

        public static User Create(string name, string password)
        {
            return new User
            {
                Id = Guid.NewGuid(),
                Name = name,
                Password = password
            };
        }
    }
}
