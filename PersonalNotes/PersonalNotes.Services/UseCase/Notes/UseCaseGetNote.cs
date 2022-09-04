using AutoMapper;
using Microsoft.AspNetCore.Http;
using PersonalNotes.Entities.Notes;
using PersonalNotes.Interfaces.Infrastructure.Repository.Notes;
using PersonalNotes.Interfaces.Services.Dto.Models.Notes;
using PersonalNotes.Interfaces.Services.Request.Notes;
using PersonalNotes.Interfaces.Services.UseCase.Notes;
using PersonalNotes.Services.Shared;
using PersonalNotes.Services.Shared.Request;

namespace PersonalNotes.Services.UseCase
{
    public class UseCaseGetNote : GetListUpdateUseCaseTemplate<Note, GetNoteRequest>, IUseCaseGetNote
    {
        private readonly IRepositoryNote _repositoryNote;
        private readonly IMapper _mapper;
        public UseCaseGetNote(IRepositoryNote repositoryNote, IMapper mapper, IHttpContextAccessor httpContext) : base(httpContext)
        {
            _repositoryNote = repositoryNote;
            _mapper = mapper;
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

        public override Task Process()
        {
            SetResult(_mapper.Map<GetNoteDto>(Entity), ResponseKind.Ok);

            return Task.CompletedTask;
        }
    }
}
