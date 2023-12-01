using E_Commerce.Bot.BotServices;
using Telegram.Bot;
using Telegram.Bot.Polling;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHostedService<BotBackgroundService>();

builder.Services.AddSingleton(new TelegramBotClient("6894570410:AAFa3MScDAHDim-7fAGL37yFZgACN_Pxjw0"));

builder.Services.AddSingleton<IUpdateHandler, UpdateHandlerService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
