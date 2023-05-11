﻿using System.Text.Json;
using System.Text.Json.Serialization;
using MySqlConnector;
using Testaufbau.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(jsonOptions =>
{
    jsonOptions.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    jsonOptions.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    jsonOptions.JsonSerializerOptions.WriteIndented = true;
});

// Database Context settings
builder.Services.AddTransient<MySqlConnection>(_ =>
    new MySqlConnection(builder.Configuration.GetConnectionString("ArticleDb")));
builder.Services.AddDbContext<ArticleDbContext>();

//only for seeding
builder.Services.AddTransient<MySqlConnection>(_ =>
    new MySqlConnection(builder.Configuration.GetConnectionString("OrderDb")));
builder.Services.AddDbContext<OrderDbContext>();


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
    var articleDbContext = scope.ServiceProvider.GetRequiredService<ArticleDbContext>();
    articleDbContext.Database.EnsureCreated();
    //articleDbContext.SeedForArticleTest();
    var orderDbContext = scope.ServiceProvider.GetRequiredService<OrderDbContext>();
    orderDbContext.Database.EnsureCreated();
    //orderDbContext.SeedForOrderTest();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();