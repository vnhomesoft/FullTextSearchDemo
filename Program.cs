using FulltextSearchDemo;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder( args );

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>( opt =>
    opt.UseNpgsql( "Host=localhost;Database=productdb;Username=postgres;Password=123456" ) );
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();