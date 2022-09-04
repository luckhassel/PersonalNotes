using Microsoft.AspNetCore.Http;
using PersonalNotes.Interfaces.Services.Request;

namespace PersonalNotes.Services.Shared
{
    public abstract class GetListUpdateUseCaseTemplate<TEntity, TRequest> : UseCaseTemplate<TRequest> where TRequest : IRequest
    {
        protected GetListUpdateUseCaseTemplate(IHttpContextAccessor context) : base(context)
        {
        }

        public TEntity? Entity { get; set; }

        public override Task Validate()
        {
            LoadEntity();

            return Task.CompletedTask;
        }

        public abstract Task LoadEntity();
    }
}
