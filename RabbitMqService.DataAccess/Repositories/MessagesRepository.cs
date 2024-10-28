using RabbitMqService.DataAccess.Entities;
using static RabbitMqService.Domain.Models.Model;
using Microsoft.EntityFrameworkCore;

namespace RabbitMqService.DataAccess.Repositories
{
    public class MessagesRepository : IMessagesRepository
    {
        private readonly MessageDbContext _context;
        public MessagesRepository(MessageDbContext context)
        {
            _context = context;
        }
        public async Task<long> CreateAsync(Message message)
        {
            var messageEntity = new MessageEntity
            {
                Request = message.Request,
                DebitPart = message.DebitPart,
                CreditPart = message.CreditPart,
                Details = message.Details,
                BankingDate = message.BankingDate,
                Attributes = message.Attributes,
                RequestDateTime = DateTime.Now,
                Status = ProcessingStatus.Received
            };

            await _context.Messages.AddAsync(messageEntity);
            await _context.SaveChangesAsync();

            return messageEntity.Request.Id;
        }
        public async Task<long> UpdateStatusToTransferred(long messageId)
        {
            await _context.Messages
                .Where(m => m.Request.Id == messageId)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(m => m.Status, ProcessingStatus.Transferred));
            return messageId;
        }
    }
}
