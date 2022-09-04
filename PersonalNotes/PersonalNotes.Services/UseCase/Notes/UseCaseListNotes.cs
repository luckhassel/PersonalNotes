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
    public class UseCaseListNotes : UseCaseTemplate<ListNotesRequest>, IUseCaseListNotes
    {
        private readonly IRepositoryNote _repositoryNote;
        private readonly IMapper _mapper;
        public UseCaseListNotes(IRepositoryNote repositoryNote, IMapper mapper, IHttpContextAccessor httpContext) : base(httpContext)
        {
            _repositoryNote = repositoryNote;
            _mapper = mapper;
        }

        public override Task Process()
        {
            List<Note> notes = _repositoryNote.ListNotes(_currentUserId, _request.InitialDate);

            if (notes != null)
            {
                SetResult(notes.Select(n => _mapper.Map<GetNoteDto>(n)).ToList(), ResponseKind.Ok);
            }
            else
            {
                SetResult(Array.Empty<Note>().ToList(), ResponseKind.Ok);
            }

            return Task.CompletedTask;
        }

        public override Task Validate()
        {
            return Task.CompletedTask;
        }
    }
}
