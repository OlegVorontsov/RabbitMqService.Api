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
                Id = Guid.NewGuid(),
                Request = new RequestEntity
                {
                    Id = message.Request.Id,
                    Document = new DocumentEntity
                    {
                        Id = message.Request.Document.Id,
                        Type = message.Request.Document.Type
                    }
                },
                DebitPart = new DebitPartEntity
                {
                    Id = Guid.NewGuid(),
                    AgreementNumber = message.DebitPart.AgreementNumber,
                    AccountNumber = message.DebitPart.AccountNumber,
                    Amount = message.DebitPart.Amount,
                    Currency = message.DebitPart.Currency,
                    Attributes = ConvertAttributes(message.DebitPart.Attributes)
                },
                CreditPart = new CreditPartEntity
                {
                    Id = Guid.NewGuid(),
                    AgreementNumber = message.CreditPart.AgreementNumber,
                    AccountNumber = message.CreditPart.AccountNumber,
                    Amount = message.CreditPart.Amount,
                    Currency = message.CreditPart.Currency,
                    Attributes = ConvertAttributes(message.CreditPart.Attributes)
                },
                Details = message.Details,
                BankingDate = message.BankingDate,
                Attributes = ConvertAttributes(message.Attributes)
            };

            messageEntity.RequestDateTime = DateTime.Now;
            messageEntity.Status = ProcessingStatus.Received;

            await _context.Messages.AddAsync(messageEntity);
            await _context.SaveChangesAsync();

            return messageEntity.Request.Id;
        }
        private static List<AttributeEntity> ConvertAttributes(dynamic attributes)
        {
            var result = new List<AttributeEntity>();
            foreach (var attribute in attributes)
            {
                var newAttribute = new AttributeEntity
                {
                    Id = Guid.NewGuid(),
                    Code = attribute.Code,
                    Value = attribute.Value
                };
                result.Add(newAttribute);
            }
            return result;
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
