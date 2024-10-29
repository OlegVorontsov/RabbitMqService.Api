using RabbitMqService.DataAccess.Entities;

namespace RabbitMqService.Domain.Models
{
    public static class ExtensionMethods
    {
        public static DebitPartAttributeEntity ConvertToDebitPartAttributes(this Model.Attribute attribute)
        {
            var result = new DebitPartAttributeEntity
            {
                Id = Guid.NewGuid(),
                Code = attribute.Code,
                Value = attribute.Value
            };
            return result;
        }
        public static CreditPartAttributeEntity ConvertToCreditPartAttributes(this Model.Attribute attribute)
        {
            var result = new CreditPartAttributeEntity
            {
                Id = Guid.NewGuid(),
                Code = attribute.Code,
                Value = attribute.Value
            };
            return result;
        }
        public static MessageAttributeEntity ConvertToMessageAttributes(this Model.Attribute attribute)
        {
            var result = new MessageAttributeEntity
            {
                Id = Guid.NewGuid(),
                Code = attribute.Code,
                Value = attribute.Value
            };
            return result;
        }
    }
}