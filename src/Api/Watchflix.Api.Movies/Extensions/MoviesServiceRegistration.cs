using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Watchflix.Api.Movies.EntityFramework;
using Watchflix.Api.Movies.Features.Rules.MovieRules;
using Watchflix.Api.Movies.Services;
using Watchflix.Api.Movies.Services.Interfaces;
using Watchflix.Shared.Pipelines;

namespace Watchflix.Api.Movies.Extensions
{
    public static class MoviesServiceRegistration
    {
        public static IServiceCollection AddRequiredServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(x =>
            {
                x.UseSqlServer(configuration.GetConnectionString("SqlCon"));
            });

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(x =>
            {
                x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


            services.AddScoped<MovieBusinessRules>();
            services.AddScoped<IMovieService, MovieService>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));

            return services;
        }
    }
}
