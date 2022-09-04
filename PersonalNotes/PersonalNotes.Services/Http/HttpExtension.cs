using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace PersonalNotes.Services.Http
{
    public static class HttpExtension
    {
        public static string GetUserId(this HttpContext httpContext)
        {
            return httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
    }
}
