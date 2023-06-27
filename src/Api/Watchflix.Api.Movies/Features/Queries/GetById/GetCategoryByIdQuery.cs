using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Watchflix.Api.Movies.EntityFramework;
using Watchflix.Api.Movies.Models.Dtos;
using Watchflix.Api.Movies.Models.Entities;

namespace Watchflix.Api.Movies.Features.Queries.GetById
{
    public class GetCategoryByIdQuery : IRequest<CategoryCreateDto>
    {
        public Guid Id { get; set; }

        public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryCreateDto>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;

            public GetCategoryByIdQueryHandler(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CategoryCreateDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
            {
                Category category = await _context.Categories
                    .FirstOrDefaultAsync(x => x.Id == request.Id);
                if (category == null)
                {
                    throw new ArgumentNullException("Kategori bulunamadı.");
                }

                return _mapper.Map<CategoryCreateDto>(category);
            }
        }
    }
}