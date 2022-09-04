using Microsoft.AspNetCore.Mvc;
using PersonalNotes.Interfaces.Services.Request.Users;
using PersonalNotes.Services.UseCase.Users;
using PersonalNotes.Test.Configuration.Context;
using PersonalNotes.Test.Configuration.Notes;
using PersonalNotes.Test.Configuration.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PersonalNotes.Test.Tests.Users
{
    public class CreateUser
    {
        [Fact]
        public void CreateUserSuccess()
        {
            var useCase = GetUseCase();
            var response = useCase.Execute(new CreateUserRequest
            {
                UserName = "user",
                Password = "password"
            });

            ObjectResult objectResponse = Assert.IsType<ObjectResult>(response);
            Assert.Equal(201, objectResponse.StatusCode);
        }

        [Fact]
        public void CreateUserAlreadyInUse()
        {
            var useCase = GetUseCase();
            var response = useCase.Execute(new CreateUserRequest
            {
                UserName = UsersConfig.GetUserName(),
                Password = "password"
            });

            ObjectResult objectResponse = Assert.IsType<ObjectResult>(response);
            Assert.Equal(400, objectResponse.StatusCode);
        }

        public static UseCaseCreateUser GetUseCase() => new(UsersConfig.GetDefault().Object, HttpContextConfig.GetHttpAccessor().Object);
    }
}
