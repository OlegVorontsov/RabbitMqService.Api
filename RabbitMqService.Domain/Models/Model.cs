
namespace RabbitMqService.Domain.Models
{
    public class Model
    {
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
            public Dictionary<string, string> Attributes { get; set; }
        }

        public class CreditPart
        {
            public string AgreementNumber { get; set; }
            public string AccountNumber { get; set; }
            public decimal Amount { get; set; }
            public string Currency { get; set; }
            public Dictionary<string, string> Attributes { get; set; }
        }

        public class Message
        {
            public Request Request { get; set; }
            public DebitPart DebitPart { get; set; }
            public CreditPart CreditPart { get; set; }
            public string Details { get; set; }
            public string BankingDate { get; set; }
            public Dictionary<string, List<Attribute>> Attributes { get; set; }
        }

        public class Attribute
        {
            public string Code { get; set; }
            public string Value { get; set; }
        }
    }
}
