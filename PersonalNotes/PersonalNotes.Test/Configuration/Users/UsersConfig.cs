using Moq;
using PersonalNotes.Entities.Users;
using PersonalNotes.Interfaces.Infrastructure.Repository.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalNotes.Test.Configuration.Users
{
    internal static class UsersConfig
    {
        internal static Guid GetUserId()
        {
            return new Guid("49a57931-8f41-4090-b6b6-4a83d505f816");
        }

        internal static string GetUserName()
        {
            return "username";
        }

        internal static Mock<IRepositoryUser> GetDefault()
        {
            var mock = new Mock<IRepositoryUser>();

            mock.Setup(m => m.GetUser(GetUserName())).Returns(new User
            {
                Id = GetUserId(),
                Name = GetUserName(),
                Password = "password"
            });

            mock.Setup(m => m.Save());

            return mock;
        }
    }
}
