using Microsoft.AspNetCore.Mvc;
using PersonalNotes.Interfaces.Services.Request.Notes;
using PersonalNotes.Services.UseCase;
using PersonalNotes.Test.Configuration.Context;
using PersonalNotes.Test.Configuration.Notes;
using System;
using Xunit;

namespace PersonalNotes.Test.Tests.Notes
{
    public class CreateNote
    {
        [Fact]
        public void CreateNoteSuccess()
        {
            var useCase = GetUseCase();
            var response = useCase.Execute(new CreateNotesRequest
            {
                StartDate = DateTime.MinValue,
                EndDate = DateTime.MaxValue,
                Subject = "subject",
                Description = "description"
            });

            ObjectResult objectResponse = Assert.IsType<ObjectResult>(response);
            Assert.Equal(201, objectResponse.StatusCode);
        }

        [Fact]
        public void CreateNoteInvalidDate()
        {
            var useCase = GetUseCase();
            var response = useCase.Execute(new CreateNotesRequest
            {
                StartDate = DateTime.MaxValue,
                EndDate = DateTime.MinValue,
                Subject = "subject",
                Description = "description"
            });

            ObjectResult objectResponse = Assert.IsType<ObjectResult>(response);
            Assert.Equal(400, objectResponse.StatusCode);
        }

        [Fact]
        public void CreateNoteInvalidSubject()
        {
            var useCase = GetUseCase();
            var response = useCase.Execute(new CreateNotesRequest
            {
                StartDate = DateTime.MinValue,
                EndDate = DateTime.MaxValue,
                Subject = null,
                Description = "description"
            });

            ObjectResult objectResponse = Assert.IsType<ObjectResult>(response);
            Assert.Equal(400, objectResponse.StatusCode);
        }

        [Fact]
        public void CreateNoteInvalidDescription()
        {
            var useCase = GetUseCase();
            var response = useCase.Execute(new CreateNotesRequest
            {
                StartDate = DateTime.MinValue,
                EndDate = DateTime.MaxValue,
                Subject = "subject",
                Description = null
            });

            ObjectResult objectResponse = Assert.IsType<ObjectResult>(response);
            Assert.Equal(400, objectResponse.StatusCode);
        }

        public static UseCaseCreateNote GetUseCase() => new (NotesConfig.GetDefault().Object, HttpContextConfig.GetHttpAccessor().Object);
    }
}
