using Microsoft.Extensions.DependencyInjection;
using PersonalNotes.Infraestructure.Data.Repository.Users;
using PersonalNotes.Infrastructure.Data.Repository.Notes;
using PersonalNotes.Interfaces.Infrastructure.Repository.Notes;
using PersonalNotes.Interfaces.Infrastructure.Repository.Users;

namespace PersonalNotes.Infrastructure
{
    public static class InfrastructureContainer
    {
        public static void AddInfrastructureContainer(this IServiceCollection service)
        {
            service.AddScoped<IRepositoryUser, RepositoryUser>();
            service.AddScoped<IRepositoryNote, RepositoryNote>();
        }
    }
}
