
namespace RabbitMqService.Domain.Models
{
    public class Model
    {
        // BusinessObject
        public class Message
        {
            public Request Request { get; set; }
            public DebitPart DebitPart { get; set; }
            public CreditPart CreditPart { get; set; }
            public string Details { get; set; }
            public string BankingDate { get; set; }
            public List<Attribute> Attributes { get; set; }
        }
        public class Request
        {
            public long Id { get; set; }
            public Document Document { get; set; }
        }

        public class Document
        {
            public long Id { get; set; }
            public string Type { get; set; }
        }

        public class DebitPart
        {
            public string AgreementNumber { get; set; }
            public string AccountNumber { get; set; }
            public decimal Amount { get; set; }
            public string Currency { get; set; }
            public List<Attribute> Attributes { get; set; }
        }

        public class CreditPart
        {
            public string AgreementNumber { get; set; }
            public string AccountNumber { get; set; }
            public decimal Amount { get; set; }
            public string Currency { get; set; }
            public List<Attribute> Attributes { get; set; }
        }

        public class Attribute
        {
            public Guid Id { get; set; }
            public string Code { get; set; } = string.Empty;
            public string Value { get; set; } = string.Empty;
        }
    }
}
