using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RabbitMqService.Api.Contracts;
using RabbitMqService.Application.Services;
using static RabbitMqService.Domain.Models.Model;

namespace RabbitMqService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RabbitMqController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public RabbitMqController(IMessageService messageService)
        {
            _messageService = messageService;
        }
        [HttpPost]
        public async Task<ActionResult<long>> CreateMessage([FromBody] JsonRequest request)
        {
            var newMessage = MessageConverter.ConvertRequestToMessage(request);

            var messageId = _messageService.ProcessMessage(newMessage);

            return Ok(messageId);
        }
        private static class MessageConverter
        {
            public static Message ConvertRequestToMessage(JsonRequest request)
            {
                var message = new Message
                {
                    Request = new Request
                    {
                        Id = request.Request.Id,
                        Document = new Document
                        {
                            Id = request.Request.Document.Id,
                            Type = request.Request.Document.Type
                        }
                    },
                    DebitPart = new DebitPart
                    {
                        AgreementNumber = request.DebitPart.AgreementNumber,
                        AccountNumber = request.DebitPart.AccountNumber,
                        Amount = request.DebitPart.Amount,
                        Currency = request.DebitPart.Currency,
                        Attributes = ConvertAttributes(request.DebitPart.Attributes)
                    },
                    CreditPart = new CreditPart
                    {
                        AgreementNumber = request.CreditPart.AgreementNumber,
                        AccountNumber = request.CreditPart.AccountNumber,
                        Amount = request.CreditPart.Amount,
                        Currency = request.CreditPart.Currency,
                        Attributes = ConvertAttributes(request.CreditPart.Attributes)
                    },
                    Details = request.Details,
                    BankingDate = request.BankingDate,
                    Attributes = ConvertAttributes(request.Attributes)
                };

                return message;
            }
        }
        private static List<Domain.Models.Model.Attribute> ConvertAttributes(dynamic attributes)
        {
            var result = new List<Domain.Models.Model.Attribute>();
            foreach (var attribute in attributes)
            {
                var newAttribute = new Domain.Models.Model.Attribute
                {
                    Code = attribute.Code,
                    Value = attribute.Value
                };
                result.Add(newAttribute);
            }
            return result;
        }
    }
}

