
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
        public List<AttributeEntity> Attributes { get; set; }
        public DateTime RequestDateTime {  get; set; }
        public ProcessingStatus Status { get; set; }
    }
    public class RequestEntity
    {
        public long Id { get; set; }
        public DocumentEntity Document { get; set; }
    }
    public class DocumentEntity
    {
        public long Id { get; set; }
        public string Type { get; set; }
    }
    public class DebitPartEntity
    {
        public Guid Id { get; set; }
        public string AgreementNumber { get; set; }
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public List<AttributeEntity> Attributes { get; set; }
    }
    public class CreditPartEntity
    {
        public Guid Id { get; set; }
        public string AgreementNumber { get; set; }
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public List<AttributeEntity> Attributes { get; set; }
    }
    public class AttributeEntity
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
    public enum ProcessingStatus
    {
        Received = 1,
        Transferred = 2,
        Error = 3
    }
}
