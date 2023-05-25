using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQMessenger.Config;
using RabbitMQMessenger.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", true, reloadOnChange: true);
var rabbitMQConfig = builder.Configuration.GetSection("RabbitMQ").Get<RabbitMQConfig>();
builder.Services.AddSingleton(rabbitMQConfig);

builder.Services.AddSingleton<RabbitMQConsumer>();



var app = builder.Build();
app.MapGet("/", (RabbitMQConsumer consumer) =>
{
    consumer.Sta;
    return "RabbitMQ consumer has started!";
});

await app.RunAsync();




Console.WriteLine("Hello, World!");
