using Microsoft.AspNetCore.Mvc;
using PersonalNotes.Interfaces.Services.Request.Notes;
using PersonalNotes.Services.UseCase;
using PersonalNotes.Test.Configuration.Context;
using PersonalNotes.Test.Configuration.Notes;
using System;
using Xunit;

namespace PersonalNotes.Test.Tests.Notes
{
    public class UpdateNote
    {
        [Fact]
        public void UpdateNoteSuccess()
        {
            var useCase = GetUseCase();
            var response = useCase.Execute(new UpdateNoteRequest
            {
                Id = NotesConfig.GetNoteId(),
                StartDate = DateTime.MinValue,
                EndDate = DateTime.MaxValue,
                Subject = "subject",
                Description = "description"
            });

            ObjectResult objectResponse = Assert.IsType<ObjectResult>(response);
            Assert.Equal(204, objectResponse.StatusCode);
        }

        [Fact]
        public void UpdateNoteInvalidDate()
        {
            var useCase = GetUseCase();
            var response = useCase.Execute(new UpdateNoteRequest
            {
                Id = NotesConfig.GetNoteId(),
                StartDate = DateTime.MaxValue,
                EndDate = DateTime.MinValue,
                Subject = "subject",
                Description = "description"
            });

            ObjectResult objectResponse = Assert.IsType<ObjectResult>(response);
            Assert.Equal(400, objectResponse.StatusCode);
        }

        [Fact]
        public void UpdateNoteInvalidSubject()
        {
            var useCase = GetUseCase();
            var response = useCase.Execute(new UpdateNoteRequest
            {
                Id = NotesConfig.GetNoteId(),
                StartDate = DateTime.MinValue,
                EndDate = DateTime.MaxValue,
                Subject = null,
                Description = "description"
            });

            ObjectResult objectResponse = Assert.IsType<ObjectResult>(response);
            Assert.Equal(400, objectResponse.StatusCode);
        }

        [Fact]
        public void UpdateNoteInvalidDescription()
        {
            var useCase = GetUseCase();
            var response = useCase.Execute(new UpdateNoteRequest
            {
                Id = NotesConfig.GetNoteId(),
                StartDate = DateTime.MinValue,
                EndDate = DateTime.MaxValue,
                Subject = "subject",
                Description = null
            }) ;

            ObjectResult objectResponse = Assert.IsType<ObjectResult>(response);
            Assert.Equal(400, objectResponse.StatusCode);
        }

        [Fact]
        public void UpdateNoteNotFound()
        {
            var useCase = GetUseCase();
            var response = useCase.Execute(new UpdateNoteRequest
            {
                Id = Guid.NewGuid(),
                StartDate = DateTime.MinValue,
                EndDate = DateTime.MaxValue,
                Subject = "subject",
                Description = null
            });

            ObjectResult objectResponse = Assert.IsType<ObjectResult>(response);
            Assert.Equal(404, objectResponse.StatusCode);
        }

        public static UseCaseUpdateNote GetUseCase() => new(NotesConfig.GetDefault().Object, HttpContextConfig.GetHttpAccessor().Object);
    }
}
