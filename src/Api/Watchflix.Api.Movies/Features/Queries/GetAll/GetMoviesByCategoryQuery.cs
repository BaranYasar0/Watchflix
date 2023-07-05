using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Watchflix.Api.Movies.EntityFramework;
using Watchflix.Api.Movies.Models.Dtos;
using Watchflix.Api.Movies.Models.Entities;

namespace Watchflix.Api.Movies.Features.Queries.GetAll
{
    public class GetMoviesByCategoryQuery:IRequest<List<GetMoviesByCategoryDto>>
    {
        public Guid Id { get; set; }
        public PageRequestDto PageRequestDto { get; set; }

        public class GetMoviesByCategoryQueryHandler:IRequestHandler<GetMoviesByCategoryQuery,List<GetMoviesByCategoryDto>>
        {
            private readonly AppDbContext _context;
            private readonly ILogger<GetMoviesByCategoryQueryHandler> _logger;
            private readonly IMapper _mapper;
            public GetMoviesByCategoryQueryHandler(AppDbContext context, ILogger<GetMoviesByCategoryQueryHandler> logger, IMapper mapper)
            {
                _context = context;
                _logger = logger;
                _mapper = mapper;
            }

            public async Task<List<GetMoviesByCategoryDto>> Handle(GetMoviesByCategoryQuery request, CancellationToken cancellationToken)
            {
                var category = await _context.Categories.Include(x => x.Movies).Where(x => x.Id == request.Id).FirstOrDefaultAsync();

                List<Movie>? movies = category?.Movies?.Skip(request.PageRequestDto.Index)
                    .Take(request.PageRequestDto.Size).OrderByDescending(o=>o.Rating).ToList();
                
                if(movies is null)
                    movies=new List<Movie>();
                return _mapper.Map<List<GetMoviesByCategoryDto>>(movies);
            }
        }
    }
}
