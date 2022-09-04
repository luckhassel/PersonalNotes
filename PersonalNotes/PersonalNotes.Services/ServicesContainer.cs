using Microsoft.Extensions.DependencyInjection;
using PersonalNotes.Interfaces.Services.UseCase.Notes;
using PersonalNotes.Interfaces.Services.UseCase.Users;
using PersonalNotes.Services.UseCase;
using PersonalNotes.Services.UseCase.Users;
using System.Reflection;

namespace PersonalNotes.Services
{
    public static class ServicesContainer
    {
        public static void AddServicesContainer(this IServiceCollection service)
        {
            service.AddScoped<IUseCaseCreateNote, UseCaseCreateNote>();
            service.AddScoped<IUseCaseGetNote, UseCaseGetNote>();
            service.AddScoped<IUseCaseListNotes, UseCaseListNotes>();
            service.AddScoped<IUseCaseUpdateNote, UseCaseUpdateNote>();

            service.AddScoped<IUseCaseCreateUser, UseCaseCreateUser>();
            service.AddScoped<IUseCaseAuthenticateUser, UseCaseAuthenticateUser>();

            service.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
