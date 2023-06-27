using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Watchflix.Api.Movies.EntityFramework;
using Watchflix.Api.Movies.Models.Dtos;
using Watchflix.Api.Movies.Models.Entities;

namespace Watchflix.Api.Movies.Features.Queries.GetAll
{
    public class GetAllCategoriesQuery : IRequest<List<CategoryQueryDto>>
    {
        public PageRequestDto PageRequestDto { get; set; }

        public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryQueryDto>>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;

            public GetAllCategoriesQueryHandler(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<CategoryQueryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
            {
                List<Category> categories = await _context.Categories.Include(x=>x.Movies).OrderByDescending(x=>x.CreatedDate).Skip(request.PageRequestDto.Index).Take(request.PageRequestDto.Size).ToListAsync();
                return _mapper.Map<List<CategoryQueryDto>>(categories);
            }
        }
    }
}
