using Microsoft.EntityFrameworkCore;
using RabbitMqService.DataAccess.Entities;

namespace RabbitMqService.DataAccess
{
    public class MessageDbContext : DbContext
    {
        public MessageDbContext(DbContextOptions<MessageDbContext> options)
            : base(options) { }
        public DbSet<MessageEntity> Messages { get; set; }
        public DbSet<RequestEntity> Requests { get; set; }
        public DbSet<DocumentEntity> Documents { get; set; }
        public DbSet<DebitPartEntity> DebitParts { get; set; }
        public DbSet<CreditPartEntity> CreditParts { get; set; }
        public DbSet<MessageAttributeEntity> MessageAttributes { get; set; }
        public DbSet<DebitPartAttributeEntity> DebitPartAttributes { get; set; }
        public DbSet<CreditPartAttributeEntity> CreditPartAttributes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MessageEntity>()
                    .HasKey(m => m.Id);
            modelBuilder.Entity<MessageEntity>()
                    .HasOne(m => m.Request)
                    .WithOne(r => r.Message);
            modelBuilder.Entity<MessageEntity>()
                .HasOne(m => m.DebitPart)
                .WithOne(d => d.Message);
            modelBuilder.Entity<MessageEntity>()
                .HasOne(m => m.CreditPart)
                .WithOne(c => c.Message);
            modelBuilder.Entity<MessageEntity>()
                .HasMany(m => m.Attributes)
                .WithOne(a => a.Message)
                .HasForeignKey(a => a.MessageId);

            modelBuilder.Entity<RequestEntity>()
                         .HasKey(r => r.Id);
            modelBuilder.Entity<RequestEntity>()
                .HasOne(r => r.Document)
                .WithOne(d => d.Request);

            modelBuilder.Entity<CreditPartEntity>()
                .HasKey(d => d.Id);
            modelBuilder.Entity<CreditPartEntity>()
                .HasMany(d => d.Attributes)
                .WithOne(a => a.CreditPart)
                .HasForeignKey(a => a.CreditPartId);

            modelBuilder.Entity<DebitPartEntity>()
                .HasKey(d => d.Id);
            modelBuilder.Entity<DebitPartEntity>()
                .HasMany(d => d.Attributes)
                .WithOne(a => a.DebitPart)
                .HasForeignKey(a => a.DebitPartId);
        }
    }
}
