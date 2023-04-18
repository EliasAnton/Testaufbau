using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Testaufbau.TestDBStuff.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Database Context settings
builder.Services.AddTransient<MySqlConnection>(_ =>
    new MySqlConnection(builder.Configuration.GetConnectionString("MariaDb")));
builder.Services.AddDbContext<MariaDbContext>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Seed Database
using (var scope = app.Services.CreateScope())
{
    var mariaDbContext = scope.ServiceProvider.GetRequiredService<MariaDbContext>();
    mariaDbContext.Database.EnsureCreated();
    mariaDbContext.Seed();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();