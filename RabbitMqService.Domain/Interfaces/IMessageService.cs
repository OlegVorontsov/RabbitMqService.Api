using RabbitMqService.Domain.Models;
using static RabbitMqService.Domain.Models.Model;

namespace RabbitMqService.Application.Services
{
    public interface IMessageService
    {
        Task<long> AddMessageToDb(Model.Message message);
        string ConvertToXml(Model.Message message);
        Task<long> ProcessMessage(Message message);
        Task SendToApi(string xml);
        Task<long> UpdateStatusToTransferred(long requestId);
    }
}