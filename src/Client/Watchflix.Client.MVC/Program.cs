using System.Net;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.CodeAnalysis.Editing;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Watchflix.Client.MVC.Controllers;
using Watchflix.Client.MVC.Handlers;
using Watchflix.Client.MVC.Services;
using Watchflix.Client.MVC.Services.Interfaces;
using Watchflix.Shared.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<TokenAuthenticationHandler>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddHttpClient<IAuthService, AuthService>(x =>
{
    x.BaseAddress = new Uri("https://localhost:5000/identity/");
});

builder.Services.AddHttpClient<IMovieService, MovieService>(x =>
{
    x.BaseAddress = new Uri("https://localhost:5000/services/catalog/movies/");
}).AddHttpMessageHandler<TokenAuthenticationHandler>();

builder.Services.AddHttpClient<ICategoryService, CategoryService>(x =>
{
    x.BaseAddress = new Uri("https://localhost:5000/services/catalog/categories/");
}).AddHttpMessageHandler<TokenAuthenticationHandler>();

builder.Services.AddMvc();

//builder.Services.AddHttpClient();



TokenOptions? tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.Configure<TokenOptions>(x => builder.Configuration.GetSection("TokenOptions").Bind(x));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opts =>
    {
        opts.LoginPath = "/Auth/Login";
        opts.Cookie.Name = "webcookie";
        opts.AccessDeniedPath = "/Home/AccessDenied";
        opts.ExpireTimeSpan = TimeSpan.FromDays(60);
        opts.SlidingExpiration = true;
    })
    .AddJwtBearer(x =>
    {
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey))
        };

    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseStatusCodePagesWithReExecute("/Home/AccessDenied", "?code={0}");



app.UseHttpsRedirection();
app.UseStaticFiles();


//app.Use(async (context, next) =>
//{
//    await next();
//    if(context.Response.StatusCode==(int)HttpStatusCode.Unauthorized)
//        context.Response.Redirect("/Auth/Login");
//});

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
