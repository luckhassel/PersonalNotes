using AutoMapper;
using Moq;

namespace PersonalNotes.Test.Configuration.Mapper
{
    internal static class MapperConfig
    {
        public static Mock<IMapper> GetMapper()
        {
            var mapper = new Mock<IMapper>();

            return mapper;
        }
    }
}
