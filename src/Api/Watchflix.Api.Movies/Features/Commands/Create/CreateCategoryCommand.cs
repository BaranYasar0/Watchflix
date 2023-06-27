using AutoMapper;
using MediatR;
using Watchflix.Api.Movies.EntityFramework;
using Watchflix.Api.Movies.Models.Dtos;
using Watchflix.Api.Movies.Models.Entities;

namespace Watchflix.Api.Movies.Features.Commands.Create
{
    public class CreateCategoryCommand:IRequest<CategoryCreateDto>
    {
        public CategoryCreateDto CategoryDto { get; set; }


        public class CreateCategoryCommandHandler:IRequestHandler<CreateCategoryCommand,CategoryCreateDto>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;

            public CreateCategoryCommandHandler(AppDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CategoryCreateDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                Category toBeAddedCategory = _mapper.Map<Category>(request.CategoryDto);
                if (toBeAddedCategory == null)
                    throw new ArgumentNullException(nameof(CreateCategoryCommand), message: "Kategori Eklenemedi");

                await _context.AddAsync(toBeAddedCategory);
                await _context.SaveChangesAsync();

                return _mapper.Map<CategoryCreateDto>(toBeAddedCategory);
            }
        }
    }
}
