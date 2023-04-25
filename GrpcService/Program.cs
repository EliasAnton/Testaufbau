using Microsoft.Extensions.DependencyInjection.Extensions;
using MySqlConnector;
using Testaufbau.DataAccess;
using ProtoBuf.Grpc.Server;
using Testaufbau.DataAccess.Grpc;

var builder = WebApplication.CreateBuilder(args);

// Database Context settings
builder.Services.AddTransient<MySqlConnection>(_ =>
    new MySqlConnection(builder.Configuration.GetConnectionString("MariaDb")));
builder.Services.AddDbContext<MariaDbContext>(ServiceLifetime.Transient);

builder.Services.AddCodeFirstGrpc(config =>
{
    config.ResponseCompressionLevel = System.IO.Compression.CompressionLevel.Optimal;
});

builder.Services.AddCodeFirstGrpcReflection();

builder.Services.TryAddTransient<IGrpcService, GrpcService.GrpcService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseRouting();

//Seed Database
using (var scope = app.Services.CreateScope())
{
    var mariaDbContext = scope.ServiceProvider.GetRequiredService<MariaDbContext>();
    mariaDbContext.Database.EnsureCreated();
    //mariaDbContext.Seed();
}

app.UseEndpoints(endpoints =>
{
    //endpoints.MapGrpcService<IGreeterService>();
    endpoints.MapGrpcService<IGrpcService>();
    endpoints.MapCodeFirstGrpcReflectionService();
});

app.Run();