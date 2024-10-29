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
    string connectionString = "Server=RabbitMqService;Host=localhost;Port=5432;Database=MessagesDb;User ID=postgres;Password=123;Timeout=300;CommandTimeout=300;Pooling=true";
    options.UseNpgsql(connectionString);
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
