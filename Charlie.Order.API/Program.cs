using Charlie.Order.API.RMQ;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<RMQPub>();
builder.Services.AddHostedService<RMQSub>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
