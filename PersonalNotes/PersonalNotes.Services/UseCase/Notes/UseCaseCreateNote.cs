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
    public class UseCaseCreateNote : UseCaseTemplate<CreateNotesRequest>, IUseCaseCreateNote
    {
        private readonly IRepositoryNote _repositoryNote;
        public UseCaseCreateNote(IRepositoryNote repositoryNote, IHttpContextAccessor httpContext) : base(httpContext)
        {
            _repositoryNote = repositoryNote;
        }

        public override Task Process()
        {
            Note note = Note.Create(_request.StartDate, _request.EndDate, _request.Subject, _request.Description, _currentUserId);

            _repositoryNote.CreateNote(note);
            _repositoryNote.Save();

            SetResult(note.Id, ResponseKind.Created);

            return Task.CompletedTask;
        }

        public override Task Validate()
        {
            var errors = CreateUpdateNoteCommonValidator.Validate(_request);

            if (errors.Any())
            {
                errors.ForEach(error => SetError(error, ResponseKind.BadRequest));
            }

            return Task.CompletedTask;
        }
    }
}
