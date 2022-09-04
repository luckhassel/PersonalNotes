using Microsoft.AspNetCore.Http;
using PersonalNotes.Entities.Notes;
using PersonalNotes.Interfaces.Infrastructure.Repository.Notes;
using PersonalNotes.Interfaces.Services.Request.Notes;
using PersonalNotes.Interfaces.Services.UseCase.Notes;
using PersonalNotes.Services.Shared;
using PersonalNotes.Services.Shared.Request;
using PersonalNotes.Services.UseCase.Common.Notes;

namespace PersonalNotes.Services.UseCase
{
    public class UseCaseUpdateNote : GetListUpdateUseCaseTemplate<Note, UpdateNoteRequest>, IUseCaseUpdateNote
    {
        private readonly IRepositoryNote _repositoryNote;
        public UseCaseUpdateNote(IRepositoryNote repositoryNote, IHttpContextAccessor httpContext) : base(httpContext)
        {
            _repositoryNote = repositoryNote;
        }

        public override Task Validate()
        {
            var errors = CreateUpdateNoteCommonValidator.Validate(_request);

            if (errors.Any())
            {
                errors.ForEach(error => SetError(error, ResponseKind.BadRequest));
            }

            return base.Validate();
        }

        public override Task LoadEntity()
        {
            Entity = _repositoryNote.GetNote(_request.Id, _currentUserId);
            if (Entity == null)
            {
                SetError("Note not found", ResponseKind.NotFound);
            }

            return Task.CompletedTask;
        }

        public async override Task Process()
        {
            Entity.Update(_request.StartDate, _request.EndDate, _request.Subject, _request.Description);

            _repositoryNote.Save();

            SetResult("", ResponseKind.Updated);
        }
    }
}
