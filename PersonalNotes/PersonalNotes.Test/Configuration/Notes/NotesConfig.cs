using Moq;
using PersonalNotes.Entities.Notes;
using PersonalNotes.Entities.Users;
using PersonalNotes.Interfaces.Infrastructure.Repository.Notes;
using PersonalNotes.Test.Configuration.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalNotes.Test.Configuration.Notes
{
    internal static class NotesConfig
    {
        internal static Guid GetNoteId()
        {
            return new Guid("49a57931-8f41-4090-b6b6-4a83d505f815");
        }
        internal static Mock<IRepositoryNote> GetDefault()
        {
            var mock = new Mock<IRepositoryNote>();

            mock.Setup(m => m.GetNote(GetNoteId(), UsersConfig.GetUserId())).Returns(new Note
            {
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Subject = "subject",
                Description = "description"
            });

            mock.Setup(m => m.Save());

            return mock;
        }
    }
}
