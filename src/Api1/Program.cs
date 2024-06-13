using OpenTelemetry.Logs;
using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

const string serviceName = "roll-dice";

//builder.Logging.AddOpenTelemetry(options =>
//{
//    options
//        .SetResourceBuilder(
//            ResourceBuilder.CreateDefault()
//                .AddService(serviceName))
//        .AddConsoleExporter();
//});
//builder.Services.AddOpenTelemetry()
//      .ConfigureResource(resource => resource.AddService(serviceName))
//      .WithTracing(tracing => tracing
//          .AddAspNetCoreInstrumentation()
//          .AddConsoleExporter())
//      .WithMetrics(metrics => metrics
//          .AddAspNetCoreInstrumentation()
//          .AddConsoleExporter());

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
