using AutoMapper;
using PersonalNotes.Entities.Notes;
using PersonalNotes.Interfaces.Services.Dto.Models.Notes;

namespace PersonalNotes.Interfaces.Services.Dto.Notes
{
    public class DtoConfig : Profile
    {
        public DtoConfig()
        {
            NoteConfig();
        }

        public void NoteConfig()
        {
            CreateMap<Note, GetNoteDto>();
        }
        
    }
}
