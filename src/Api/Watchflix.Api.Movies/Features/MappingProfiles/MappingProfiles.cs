using AutoMapper;
using Watchflix.Api.Movies.Features.Commands.Create;
using Watchflix.Api.Movies.Features.Queries.GetAll;
using Watchflix.Api.Movies.Models.Dtos;
using Watchflix.Api.Movies.Models.Entities;

namespace Watchflix.Api.Movies.Features.MappingProfiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<CategoryCreateDto, Category>().ReverseMap();

            CreateMap<CreateMovieDto, Movie>().ReverseMap();


            CreateMap<CreateMovieResponseDto, Movie>()
                .ForMember(x => x.Category, y => y.MapFrom(z => z.CategoryResponseDtos)).ReverseMap();
            CreateMap<CategoryWithMovieDto, Movie>().ReverseMap();

            CreateMap<CategoryQueryDto, Category>().ForMember(x=>x.Movies,y=>y.MapFrom(x=>x.CategoryWithMovieDtos)).ReverseMap();

            CreateMap<CategoryResponseDto, Category>().ReverseMap();
            CreateMap<Movie,MovieQueryDto>().ForMember(x => x.CategoryResponseDto, y => y.MapFrom(x => x.Category)).ReverseMap();
        }

    }
}
