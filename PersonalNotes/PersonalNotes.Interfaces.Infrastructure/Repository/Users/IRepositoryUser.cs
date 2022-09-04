using PersonalNotes.Entities.Users;

namespace PersonalNotes.Interfaces.Infrastructure.Repository.Users
{
    public interface IRepositoryUser
    {
        Task CreateUser(User user);
        User? GetUser(string userName);
        void Save();
    }
}
