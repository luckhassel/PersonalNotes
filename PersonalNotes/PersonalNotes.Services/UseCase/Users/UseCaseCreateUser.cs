using Microsoft.AspNetCore.Http;
using PersonalNotes.Entities.Users;
using PersonalNotes.Interfaces.Infrastructure.Repository.Users;
using PersonalNotes.Interfaces.Services.Request.Users;
using PersonalNotes.Interfaces.Services.UseCase.Users;
using PersonalNotes.Services.Authentication.Password;
using PersonalNotes.Services.Shared;
using PersonalNotes.Services.Shared.Request;

namespace PersonalNotes.Services.UseCase.Users
{
    public class UseCaseCreateUser : UseCaseTemplate<CreateUserRequest>, IUseCaseCreateUser
    {
        private readonly IRepositoryUser _repositoryUser;
        public UseCaseCreateUser(IRepositoryUser repositoryUser, IHttpContextAccessor httpContext) : base(httpContext)
        {
            _repositoryUser = repositoryUser;
        }
        public async override Task Process()
        {
            User user = User.Create(_request.UserName, PasswordService.HashPassword(_request.Password));

            await _repositoryUser.CreateUser(user);
            _repositoryUser.Save();

            SetResult(user.Id, ResponseKind.Created);
        }

        public override Task Validate()
        {
            if (_request.UserName == null)
            {
                SetError("Name is obligatory", ResponseKind.BadRequest);
            }

            if (_request.Password == null)
            {
                SetError("Password is obligatory", ResponseKind.BadRequest);
            }

            if(_repositoryUser.GetUser(_request.UserName) != null)
            {
                SetError("Username already registered", ResponseKind.BadRequest);
            }

            return Task.CompletedTask;
        }
    }
}
