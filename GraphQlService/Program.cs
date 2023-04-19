using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Server;
using GraphQL.Types;
using GraphQL.Server.Transports.AspNetCore;
using GraphQL.SystemTextJson;

var builder = WebApplication.CreateBuilder(args);

// Add GraphQL-services to the container.

builder.Services.AddGraphQL(b => b
    .AddHttpMiddleware<ISchema>()
    .AddUserContextBuilder(httpContext => new GraphQLUserContext { User = httpContext.User })
    .AddSystemTextJson()
    .AddErrorInfoProvider(opt => opt.ExposeExceptionStackTrace = true)
    .AddSchema<StarWarsSchema>()
    .AddGraphTypes(typeof(StarWarsSchema).Assembly));

//builder.Services.AddSingleton<StarWarsData>();
builder.Services.AddLogging(builder => builder.AddConsole());
builder.Services.AddHttpContextAccessor();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseGraphQL<ISchema>();
app.UseGraphQLAltair();
//app.UseGraphQLPlayground();

app.Run();