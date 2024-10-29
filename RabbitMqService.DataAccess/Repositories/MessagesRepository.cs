using RabbitMqService.DataAccess.Entities;
using static RabbitMqService.Domain.Models.Model;
using Microsoft.EntityFrameworkCore;
using System;
using RabbitMqService.Domain.Models;

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
                    Attributes = message.DebitPart.Attributes.Select(a => a.ConvertToDebitPartAttributes()).ToList()
                },
                CreditPart = new CreditPartEntity
                {
                    Id = Guid.NewGuid(),
                    AgreementNumber = message.CreditPart.AgreementNumber,
                    AccountNumber = message.CreditPart.AccountNumber,
                    Amount = message.CreditPart.Amount,
                    Currency = message.CreditPart.Currency,
                    Attributes = message.CreditPart.Attributes.Select(a => a.ConvertToCreditPartAttributes()).ToList()
                },
                Details = message.Details,
                BankingDate = message.BankingDate,
                Attributes = message.Attributes.Select(a => a.ConvertToMessageAttributes()).ToList()
            };

            messageEntity.RequestDateTime = DateTime.Now;
            messageEntity.Status = ProcessingStatus.Received;

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
