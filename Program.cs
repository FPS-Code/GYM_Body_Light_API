using Microsoft.EntityFrameworkCore;
using GYM_Body_Light_API.Src.Data;
using GYM_Body_Light_API.Src.Models;
using GYM_Body_Light_API.Src.Repositories;
using GYM_Body_Light_API.Src.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite("Data Source=catedra1.db");
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();

