using Microsoft.AspNetCore.Mvc;
using PersonalNotes.Interfaces.Services.Request.Notes;
using PersonalNotes.Services.UseCase;
using PersonalNotes.Test.Configuration.Context;
using PersonalNotes.Test.Configuration.Mapper;
using PersonalNotes.Test.Configuration.Notes;
using System;
using Xunit;

namespace PersonalNotes.Test.Tests.Notes
{
    public class GetNote
    {
        [Fact]
        public void GetNoteSuccess()
        {
            var useCase = GetUseCase();
            var response = useCase.Execute(new GetNoteRequest
            {
                Id = NotesConfig.GetNoteId()
            });

            ObjectResult objectResponse = Assert.IsType<ObjectResult>(response);
            Assert.Equal(200, objectResponse.StatusCode);
        }

        [Fact]
        public void GetNoteNotFound()
        {
            var useCase = GetUseCase();
            var response = useCase.Execute(new GetNoteRequest
            {
                Id = Guid.NewGuid()
            });

            ObjectResult objectResponse = Assert.IsType<ObjectResult>(response);
            Assert.Equal(404, objectResponse.StatusCode);
        }

        public static UseCaseGetNote GetUseCase() => new(NotesConfig.GetDefault().Object, MapperConfig.GetMapper().Object, HttpContextConfig.GetHttpAccessor().Object);
    }
}
