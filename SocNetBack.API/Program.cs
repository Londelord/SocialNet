using Microsoft.EntityFrameworkCore;
using SocNetBack.Application.Services;
using SocNetBack.Data.DataAccess;
using SocNetBack.Data.Repositories;
using SocNetBack.Domain.Stores;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<IUserStore, UsersRepository>();

builder.Services.AddDbContext<SocNetDbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString("Database"));
    },
    ServiceLifetime.Scoped);

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

app.Run();