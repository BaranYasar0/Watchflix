using AutoMapper;
using MediatR;
using Watchflix.Api.Movies.EntityFramework;
using Watchflix.Api.Movies.Features.Rules.MovieRules;
using Watchflix.Api.Movies.Models.Dtos;
using Watchflix.Api.Movies.Models.Entities;

namespace Watchflix.Api.Movies.Features.Commands.Update
{
    public class UpdateMovieCategoryCommand:IRequest<CreateMovieDto>
    {
        public Guid Id { get; set; }
        public List<CategoryCreateDto> CategoryDto { get; set; }

        public class UpdateMovieCategoryCommandHandler : IRequestHandler<UpdateMovieCategoryCommand, CreateMovieDto>
        {

            private readonly AppDbContext _context;
            private readonly ILogger<UpdateMovieCategoryCommandHandler> _logger;
            private readonly IMapper _mapper;
            private readonly MovieBusinessRules _businessRules;

            public UpdateMovieCategoryCommandHandler(AppDbContext context, ILogger<UpdateMovieCategoryCommandHandler> logger, IMapper mapper, MovieBusinessRules businessRules)
            {
                _context = context;
                _logger = logger;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<CreateMovieDto> Handle(UpdateMovieCategoryCommand request, CancellationToken cancellationToken)
            {
                Movie toBeUpdatedMovie = await _context.Movies.FindAsync(request.Id);

                await _businessRules.CheckEntityNullOrNot(toBeUpdatedMovie);

                //toBeUpdatedMovie.Category(_mapper.Map<Category>(request.CategoryDto));
                _context.Movies.Update(toBeUpdatedMovie);
                await _context.SaveChangesAsync();

                return _mapper.Map<CreateMovieDto>(toBeUpdatedMovie);
            }
        }
    }
}
