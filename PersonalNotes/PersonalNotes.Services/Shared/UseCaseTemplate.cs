using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonalNotes.Interfaces.Services.Request;
using PersonalNotes.Services.Http;
using PersonalNotes.Services.Shared.Request;

namespace PersonalNotes.Services.Shared
{
    public abstract class UseCaseTemplate<TRequest> where TRequest : IRequest
    {
        protected TRequest? _request { get; set; }
        protected ObjectResult? _result { get; set; }
        protected ObjectResult? _error { get; set; }
        protected Guid _currentUserId { get; set; }

        private readonly IHttpContextAccessor _context;

        protected UseCaseTemplate(IHttpContextAccessor context)
        {
            _context = context;

            var user = _context.HttpContext.GetUserId();
            _currentUserId = user == null ? Guid.NewGuid() : new Guid(_context.HttpContext.GetUserId());
        }

        public void SetResult(dynamic result, ResponseKind status)
        {
            _result = new(result);
            _result.StatusCode = (int)status;
        }

        public void SetError(string error, ResponseKind status)
        {
            _error = new(error);
            _error.StatusCode = (int)status;
        }

        public IActionResult Execute(TRequest request)
        {
            _request = request;

            Validate();

            if (_error != null)
            {
                return _error;
            }

            Process();

            return _result;
        }

        public abstract Task Validate();

        public abstract Task Process();
    }
}
