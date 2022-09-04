using Microsoft.AspNetCore.Mvc;
using PersonalNotes.Interfaces.Services.Request;

namespace PersonalNotes.Interfaces.Services
{
    public interface IUseCase<TRequest> where TRequest : IRequest
    {
        IActionResult Execute(TRequest request);
    }
}
