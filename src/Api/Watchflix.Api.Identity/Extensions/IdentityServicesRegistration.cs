using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Watchflix.Api.Identity.Application.Features.Rules;
using Watchflix.Api.Identity.Application.Helpers.JWT;
using Watchflix.Api.Identity.EntityFramework;
using Watchflix.Api.Identity.Services;
using Watchflix.Api.Identity.Services.Interfaces;

namespace Watchflix.Api.Identity.Extensions
{
    public static class IdentityServicesRegistration
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("SqlCon"));
            });

            services.AddScoped<ITokenHelper, JwtHelper>();
            services.AddScoped<AuthBusinessRules>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
