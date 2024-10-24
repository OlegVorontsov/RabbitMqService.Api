using RabbitMqService.DataAccess.Entities;
using static RabbitMqService.Domain.Models.Model;

namespace RabbitMqService.DataAccess.Repositories
{
    public class MessagesRepository : IMessagesRepository
    {
        private readonly MessageDbContext _context;
        public MessagesRepository(MessageDbContext context)
        {
            _context = context;
        }
        public async Task<long> Create(Message message)
        {
            var messageEntity = new MessageEntity
            {
                Request = message.Request,
                DebitPart = message.DebitPart,
                CreditPart = message.CreditPart,
                Details = message.Details,
                BankingDate = message.BankingDate,
                Attributes = message.Attributes,
                RequestDateTime = DateTime.Now
            };

            await _context.Messages.AddAsync(messageEntity);
            await _context.SaveChangesAsync();

            return messageEntity.Request.Id;
        }
    }
}
