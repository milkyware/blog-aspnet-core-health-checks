using AspNetCoreHealthChecks;
using Microsoft.Extensions.Azure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddHttpClient<IFakerClient, FakerClient>();

builder.Services.AddAzureClients(configure =>
{
    configure.AddBlobServiceClient("UseDevelopmentStorage=true");
});
var healthCheckBuilder = builder.Services.AddHealthChecks()
    .AddAzureBlobStorage()
    .AddCheck<FakerHealthCheck>("faker");
// Uncomment and to see unhealthy response
//healthCheckBuilder.AddCheck<BrokenHealthCheck>("broken");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapHealthChecks("/healthz");

await app.RunAsync();
