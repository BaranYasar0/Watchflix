using Watchflix.Api.Movies.EntityFramework;
using Watchflix.Api.Movies.Models.Entities;
using Watchflix.Api.Movies.Models.Exceptions;
using Watchflix.Api.Movies.Services.Interfaces;

namespace Watchflix.Api.Movies.Services
{
    public class MovieService:IMovieService
    {
        private readonly AppDbContext _context;

        public MovieService(AppDbContext context)
        {
            _context = context;
        }

        public async Task SyncMovieWithCategoriesAsync(List<Guid> categoryIds, Movie movie)
        {
            var categories = new List<Category>();
            Category temp=new Category();
            foreach (var categoryId in categoryIds)
            {
                temp = await _context.Categories.FindAsync(categoryId);
                Console.WriteLine(temp.Name);
                categories.Add(temp);
            }
            if (categories is null)
                throw new BusinessException("Kategori bulunamadı veya mevcut degil!");

            //movie.Category = categories;

            foreach (var category in categories)
            {
                if (category is not null)
                {
                    movie.Id=Guid.NewGuid();
                    category.Movies.Add(movie);
                    _context.Categories.Update(category);
                }
            }
            
                await _context.SaveChangesAsync();
        }
    }
}
