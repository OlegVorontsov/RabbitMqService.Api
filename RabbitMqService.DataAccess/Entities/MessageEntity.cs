
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static RabbitMqService.Domain.Models.Model;

namespace RabbitMqService.DataAccess.Entities
{
    public class MessageEntity
    {
        public Guid Id { get; set; }
        public RequestEntity Request { get; set; }
        public DebitPartEntity DebitPart { get; set; }
        public CreditPartEntity CreditPart { get; set; }
        public string Details { get; set; }
        public string BankingDate { get; set; }
        public List<MessageAttributeEntity> Attributes { get; set; } = new();
        public DateTime RequestDateTime {  get; set; }
        public ProcessingStatus Status { get; set; }
    }
    // done
    public class RequestEntity
    {
        public long Id { get; set; }
        public Guid MessageId { get; set; }
        public MessageEntity Message { get; set; }
        public DocumentEntity Document { get; set; }
    }
    // done
    public class DocumentEntity
    {
        public long Id { get; set; }
        public long RequestId { get; set; }
        public string Type { get; set; }
        public RequestEntity Request { get; set; }
    }
    public class DebitPartEntity
    {
        public Guid Id { get; set; }
        public Guid MessageId { get; set; }
        public string AgreementNumber { get; set; }
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public MessageEntity Message { get; set; }
        public List<DebitPartAttributeEntity> Attributes { get; set; } = new();
    }
    public class CreditPartEntity
    {
        public Guid Id { get; set; }
        public Guid MessageId { get; set; }
        public string AgreementNumber { get; set; }
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public MessageEntity Message { get; set; }
        public List<CreditPartAttributeEntity> Attributes { get; set; } = new();
    }
    public class MessageAttributeEntity
    {
        public Guid Id { get; set; }
        public Guid MessageId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public MessageEntity Message { get; set; }
    }
    public class DebitPartAttributeEntity
    {
        public Guid Id { get; set; }
        public Guid DebitPartId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public DebitPartEntity DebitPart { get; set; }
    }
    public class CreditPartAttributeEntity
    {
        public Guid Id { get; set; }
        public Guid CreditPartId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public CreditPartEntity CreditPart { get; set; }
    }
    public enum ProcessingStatus
    {
        Received = 1,
        Transferred = 2,
        Error = 3
    }
}
