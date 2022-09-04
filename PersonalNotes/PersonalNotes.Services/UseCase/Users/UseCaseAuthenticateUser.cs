using Microsoft.AspNetCore.Http;
using PersonalNotes.Entities.Users;
using PersonalNotes.Interfaces.Infrastructure.Repository.Users;
using PersonalNotes.Interfaces.Services.Request.Users;
using PersonalNotes.Interfaces.Services.UseCase.Users;
using PersonalNotes.Services.Authentication;
using PersonalNotes.Services.Authentication.Password;
using PersonalNotes.Services.Shared;
using PersonalNotes.Services.Shared.Request;

namespace PersonalNotes.Services.UseCase.Users
{
    public class UseCaseAuthenticateUser : GetListUpdateUseCaseTemplate<User, AuthenticateUserRequest>, IUseCaseAuthenticateUser
    {
        private readonly IRepositoryUser _repositoryUser;
        public UseCaseAuthenticateUser(IRepositoryUser repositoryUser, IHttpContextAccessor httpContext) : base(httpContext)
        {
            _repositoryUser = repositoryUser;
        }
        public override Task LoadEntity()
        {
            Entity = _repositoryUser.GetUser(_request.UserName);

            if (Entity != null)
            {
                if (!PasswordService.IsPasswordCorrect(_request.Password, Entity.Password))
                {
                    SetError("Wrong password", ResponseKind.BadRequest);
                }
            }
            else
            {
                SetError("User not found", ResponseKind.NotFound);
            }

            return Task.CompletedTask;
        }

        public override Task Process()
        {
            SetResult(new { user = Entity.Name, token = TokenService.GenerateToken(Entity) }, ResponseKind.Ok);

            return Task.CompletedTask;
        }
    }
}
