using PersonalNotes.Entities.Users;
using PersonalNotes.Infraestructure.Data.Context;
using PersonalNotes.Interfaces.Infrastructure.Repository.Users;

namespace PersonalNotes.Infraestructure.Data.Repository.Users
{
    public class RepositoryUser : IRepositoryUser
    {
        private readonly PersonalNotesContext _context;
        public RepositoryUser(PersonalNotesContext context)
        {
            _context = context;
        }
        public async Task CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public User? GetUser(string userName)
        {
            return _context.Users.FirstOrDefault(u => u.Name == userName);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
