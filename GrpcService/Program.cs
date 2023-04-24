using GrpcService.Services;
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

builder.Services.TryAddTransient<IGreeterService, GreeterService>();
builder.Services.TryAddTransient<IGrpcService, GrpcService.Services.GrpcService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<IGreeterService>();
    endpoints.MapGrpcService<IGrpcService>();
    endpoints.MapCodeFirstGrpcReflectionService();
});

app.Run();