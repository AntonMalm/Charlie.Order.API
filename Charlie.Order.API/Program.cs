using Charlie.Order.API;
using Charlie.Order.API.RMQ;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<RMQPub>(provider => new RMQPub("amqp://guest:guest@DIN-DATOR-IP/"));
builder.Services.AddScoped<IOrderRMQService, OrderRMQService>();

// Kommenterar bort för att denna inte är klar
//builder.Services.AddHostedService<RMQSub>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapControllers();
app.Run();
