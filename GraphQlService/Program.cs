using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Server;
using GraphQL.SystemTextJson;
using MySqlConnector;
using Testaufbau.DataAccess;
using Testaufbau.DataAccess.GraphQl;

var builder = WebApplication.CreateBuilder(args);

// Add configuration from appsettings.json

// Database Context settings
builder.Services.AddTransient<MySqlConnection>(_ =>
    new MySqlConnection(builder.Configuration.GetConnectionString("MariaDb")));
builder.Services.AddDbContext<MariaDbContext>(ServiceLifetime.Transient);

// Add GraphQL-services to the container.
builder.Services.AddGraphQL(b => b
    .AddHttpMiddleware<GraphQlSchema>()
    .AddUserContextBuilder(httpContext => new GraphQlUserContext { User = httpContext.User })
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
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseGraphQL<GraphQlSchema>();
app.UseGraphQLPlayground();

app.Run();