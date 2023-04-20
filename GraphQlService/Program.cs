using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Server;
using GraphQL.Types;
using GraphQL.SystemTextJson;
using GraphQlService;
using GraphQlService.Models;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Testaufbau.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add configuration from appsettings.json

// Database Context settings
builder.Services.AddTransient<MySqlConnection>(_ =>
    new MySqlConnection(builder.Configuration.GetConnectionString("MariaDb")));
builder.Services.AddDbContext<MariaDbContext>(ServiceLifetime.Transient);

// Add GraphQL-services to the container.
builder.Services.AddGraphQL(b => b
    .AddHttpMiddleware<GraphQlSchema>()
    .AddUserContextBuilder(httpContext => new GraphQLUserContext { User = httpContext.User })
    .AddSystemTextJson()
    .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true)
    .AddSchema<GraphQlSchema>()
    .AddGraphTypes(typeof(GraphQlSchema).Assembly));

builder.Services.AddLogging(b => b.AddConsole());
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

//Seed Database
using (var scope = app.Services.CreateScope())
{
    var mariaDbContext = scope.ServiceProvider.GetRequiredService<MariaDbContext>();
    mariaDbContext.Database.EnsureCreated();
    //mariaDbContext.Seed();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseGraphQL<GraphQlSchema>();
//app.UseGraphQLAltair();
app.UseGraphQLPlayground();

app.Run();