using Microsoft.EntityFrameworkCore;
using RabbitMqService.DataAccess.Entities;

namespace RabbitMqService.DataAccess
{
    public class MessageDbContext : DbContext
    {
        public MessageDbContext(DbContextOptions<MessageDbContext> options)
            : base(options) { }
        public DbSet<MessageEntity> Messages { get; set; }
    }
}
