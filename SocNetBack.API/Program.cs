using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SocNetBack.API;
using SocNetBack.API.Extensions;
using SocNetBack.Application;
using SocNetBack.Application.Interfaces;
using SocNetBack.Application.Services;
using SocNetBack.Data.DataAccess;
using SocNetBack.Data.Repositories;
using SocNetBack.Domain.Stores;
using SocNetBack.Infrastructure;
using SocNetBack.Infrastructure.Auth;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<IUserStore, UsersRepository>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));

builder.Services.AddApiAuthentication(builder.Services.BuildServiceProvider().GetRequiredService<IOptions<JwtOptions>>());

builder.Services.AddDbContext<SocNetDbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("Database"));
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("BlazorPolicy", corsPolicyBuilder =>
    {
        corsPolicyBuilder.WithOrigins("http://localhost:5241")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
    
    options.AddPolicy("AllowAnyPolicy", corsPolicyBuilder =>
    {
        corsPolicyBuilder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseCors("BlazorPolicy");
app.UseCors("AllowAnyPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.Run();