using AutoMapper;
using MediatR;
using Watchflix.Api.Movies.EntityFramework;
using Watchflix.Api.Movies.Features.Rules.MovieRules;
using Watchflix.Api.Movies.Models.Dtos;
using Watchflix.Api.Movies.Models.Entities;
using Watchflix.Api.Movies.Services.Interfaces;

namespace Watchflix.Api.Movies.Features.Commands.Create
{
    public class CreateMovieCommand : IRequest<CreateMovieResponseDto>
    {
        public CreateMovieDto CreateMovieDto { get; set; }

        public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, CreateMovieResponseDto>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;
            private readonly MovieBusinessRules _businessRules;
            private readonly IMovieService _movieService;

            public CreateMovieCommandHandler(AppDbContext context, IMapper mapper, MovieBusinessRules businessRules, IMovieService movieService)
            {
                _context = context;
                _mapper = mapper;
                _businessRules = businessRules;
                _movieService = movieService;
            }

            public async Task<CreateMovieResponseDto> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
            {

                Movie addedMovie = _mapper.Map<Movie>(request.CreateMovieDto);

                await _businessRules.CheckEntityNullOrNot(addedMovie);
                await _businessRules.MovieNameCannotBeExist(addedMovie.Name);

                //await _movieService.SyncMovieWithCategoriesAsync(request.CreateMovieDto.CategoryIds, addedMovie);

                await _context.AddAsync(addedMovie);
                await _context.SaveChangesAsync();

                return _mapper.Map<CreateMovieResponseDto>(addedMovie);
            }
        }
    }
}
