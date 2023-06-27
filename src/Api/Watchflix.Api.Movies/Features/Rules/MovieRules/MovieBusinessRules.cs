using Microsoft.EntityFrameworkCore;
using Watchflix.Api.Movies.EntityFramework;
using Watchflix.Api.Movies.Models.Entities;
using Watchflix.Api.Movies.Models.Exceptions;

namespace Watchflix.Api.Movies.Features.Rules.MovieRules
{
    public class MovieBusinessRules:BaseBusinessRules<Movie>
    {
        private readonly AppDbContext _context;

        public MovieBusinessRules(AppDbContext context)
        {
            _context = context;
        }

        public async Task CategoryNameShouldBeExist(List<string> categoryName)
        {
            if (!(await _context.Categories.AnyAsync(x=>categoryName.Contains(x.Name))))
                throw new BusinessException($"Kategori Mevcut degil!");
        }

        public async Task MovieNameCannotBeExist(string movieName)
        {
            if (await _context.Movies.AnyAsync(x => x.Name == movieName))
                throw new BusinessException($"{movieName} filmi zaten Mevcut.");
        }
    }
}
