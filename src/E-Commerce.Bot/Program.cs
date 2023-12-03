using E_Commerce.Application;
using E_Commerce.Bot.BackgroundServices;
using E_Commerce.Bot.BotServices;
using E_Commerce.Infrastructure;
using Telegram.Bot;
using Telegram.Bot.Polling;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<BotBackgroundService>();

builder.Services.AddSingleton(new TelegramBotClient("6894570410:AAFa3MScDAHDim-7fAGL37yFZgACN_Pxjw0"));

builder.Services.AddSingleton<IUpdateHandler, UpdateHandlerService>();

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();

var app = builder.Build();

app.Run();
