
using static RabbitMqService.Domain.Models.Model;

namespace RabbitMqService.DataAccess.Entities
{
    public class MessageEntity
    {
        public Request Request { get; set; }
        public DebitPart DebitPart { get; set; }
        public CreditPart CreditPart { get; set; }
        public string Details { get; set; }
        public string BankingDate { get; set; }
        public List<Domain.Models.Model.Attribute> Attributes { get; set; }
        public DateTime RequestDateTime {  get; set; }
        public ProcessingStatus Status { get; set; }
    }
    public enum ProcessingStatus
    {
        Received = 1,
        Transferred = 2,
        Error = 3
    }
}
