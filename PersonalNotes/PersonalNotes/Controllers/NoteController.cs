using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalNotes.Interfaces.Services.Request.Notes;
using PersonalNotes.Interfaces.Services.UseCase.Notes;

namespace PersonalNotes.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/note")]
    public class NoteController : ControllerBase
    {
        private readonly IUseCaseCreateNote _useCaseCreateNote;
        private readonly IUseCaseGetNote _useCaseGetNote;
        private readonly IUseCaseListNotes _useCaseListNotes;
        private readonly IUseCaseUpdateNote _useCaseUpdateNote;

        public NoteController(IUseCaseCreateNote useCaseCreateNote, IUseCaseGetNote useCaseGetNote, IUseCaseListNotes listNotes
            , IUseCaseUpdateNote useCaseUpdateNote)
        {
            _useCaseCreateNote = useCaseCreateNote;
            _useCaseGetNote = useCaseGetNote;
            _useCaseListNotes = listNotes;
            _useCaseUpdateNote = useCaseUpdateNote;
        }

        [HttpPost]
        public IActionResult CreateNote([FromBody] CreateNotesRequest request)
        {
            return _useCaseCreateNote.Execute(request);
        }

        [HttpGet("{noteId}")]
        public IActionResult GetNote([FromRoute] Guid noteId)
        {
            return _useCaseGetNote.Execute(new GetNoteRequest
            {
                Id = noteId
            });
        }

        [HttpGet]
        public IActionResult ListNotes([FromQuery] DateTime? initialDate = null)
        {
            return _useCaseListNotes.Execute(new ListNotesRequest
            {
                InitialDate = initialDate
            });
        }

        [HttpPut("{noteId}")]
        public IActionResult UpdateNote([FromRoute] Guid noteId, [FromBody] UpdateNoteRequest request)
        {
            request.Id = noteId;

            return _useCaseUpdateNote.Execute(request);
        }
    }
}