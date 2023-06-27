using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Watchflix.Api.Movies.EntityFramework;
using Watchflix.Api.Movies.Models.Dtos;
using Watchflix.Api.Movies.Models.Entities;

namespace Watchflix.Api.Movies.Features.Queries.GetById
{
    public class GetMovieByIdQuery:IRequest<MovieQueryDto>
    {
        public Guid Id { get; set; }

        public class GetMovieByIdQueryHandler:IRequestHandler<GetMovieByIdQuery,MovieQueryDto>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;

            public GetMovieByIdQueryHandler(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<MovieQueryDto> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
            {
                Movie movie = await _context.Movies.Include(x => x.Category)
                    .FirstOrDefaultAsync(x => x.Id == request.Id);
                if (movie == null)
                {
                    throw new ArgumentNullException("Film bulunamadı.");
                }

                return _mapper.Map<MovieQueryDto>(movie);
            }
        }
    }
}
