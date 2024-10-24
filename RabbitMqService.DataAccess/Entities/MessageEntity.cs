
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
        public Dictionary<string, List<Domain.Models.Model.Attribute>> Attributes { get; set; }
        public DateTime RequestDateTime {  get; set; }
    }
}
