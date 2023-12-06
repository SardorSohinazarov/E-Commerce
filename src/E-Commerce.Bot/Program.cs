using E_Commerce.Application;
using E_Commerce.Bot.BackgroundServices;
using E_Commerce.Bot.BotServices;
using E_Commerce.Infrastructure;
using Telegram.Bot;
using Telegram.Bot.Polling;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<BotBackgroundService>();
builder.Services.AddSingleton(new TelegramBotClient(builder.Configuration["TelegramBotAPIKey"]));
builder.Services.AddSingleton<IUpdateHandler, UpdateHandlerService>();

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();

/* Serilog implementation
 * Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.TeleSink("6668691456:AAFVKAI9X2J4FUMX37yTzA2DwmGbdQZvKD4", "5617428170")
    .WriteTo.File("log.txt")
    .CreateLogger();

builder.Logging.AddSerilog();*/

var app = builder.Build();

app.Run();
