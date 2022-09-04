using Microsoft.AspNetCore.Http;
using Moq;
using PersonalNotes.Test.Configuration.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PersonalNotes.Test.Configuration.Context
{
    internal class HttpContextConfig
    {
        internal static Mock<IHttpContextAccessor> GetHttpAccessor()
        {
            var _httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            _httpContextAccessorMock.Setup(x => x.HttpContext).Returns(new DefaultHttpContext
            {
                User = new ClaimsPrincipal(new List<ClaimsIdentity>
                    {
                        new ClaimsIdentity(new List<Claim>()
                        {
                            new Claim(ClaimTypes.NameIdentifier, UsersConfig.GetUserId().ToString())
                        })
                    })
            });
            return _httpContextAccessorMock;
        }
    }
}
