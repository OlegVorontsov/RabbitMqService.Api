using RabbitMqService.Application.Services;
using RabbitMqService.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using RabbitMqService.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MessageDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(MessageDbContext)));
});

builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IMessagesRepository, MessagesRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
