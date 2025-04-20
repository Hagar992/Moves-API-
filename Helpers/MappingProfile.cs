using AutoMapper;
using Moves_API_.Dtos;

namespace Moves_API_.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MoviesDetailsDto>();
            CreateMap<MovieDto, Movie>()
                .ForMember(src => src.Poster, opt => opt.Ignore());
        }
    }
}