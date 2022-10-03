using Microsoft.EntityFrameworkCore;
using OneLookAPI.Models;

var builder = WebApplication.CreateBuilder(args);
var OneLookConnectionString = builder.Configuration.GetConnectionString("OneLookConnectionString");
var OneLookCors = "OneLookCors";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<OneLookContext>(options =>
{
    options.UseSqlServer(OneLookConnectionString);
});
builder.Services.AddCors(options =>
{
    options.AddPolicy(OneLookCors, builder =>
    {
        builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(OneLookCors);

app.UseAuthorization();

app.MapControllers();

app.Run();
