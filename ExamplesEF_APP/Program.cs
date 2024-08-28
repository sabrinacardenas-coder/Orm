using ExamplesEF.Data;
using ExamplesEF.Manager;
using ExamplesEF.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar la cadena de conexión y el DbContext
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Northwind")));


// Configurar la cadena de conexión y el DbContext
builder.Services.AddDbContext<DataContextBanco>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BANCO")));

builder.Services.AddTransient<MangerEmployee>();
builder.Services.AddTransient<ManagerBanco>();

builder.Services.AddTransient<INorthwindRepository, NorthwindRepository>();

builder.Services.AddTransient<IBancoRepository, BancoRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
