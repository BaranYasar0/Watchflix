using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Watchflix.Api.Movies.EntityFramework;
using Watchflix.Api.Movies.Models.Dtos;
using Watchflix.Api.Movies.Models.Entities;
using Watchflix.Shared.Pipelines;

namespace Watchflix.Api.Movies.Features.Queries.GetAll
{
    public class GetAllMoviesQuery : IRequest<List<MovieQueryDto>>,ISecuredRequest
    {
        public PageRequestDto PageRequestDto { get; set; }
        public string[] Roles => new[] { "Admin" };

        public class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, List<MovieQueryDto>>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;

            public GetAllMoviesQueryHandler(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }


            public async Task<List<MovieQueryDto>> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
            {
                List<Movie> movies = await _context.Movies.Include(x => x.Category).OrderByDescending(x => x.CreatedDate).Skip(request.PageRequestDto.Index).Take(request.PageRequestDto.Size).ToListAsync();
                return _mapper.Map<List<MovieQueryDto>>(movies);
            }
        }

    }
}
