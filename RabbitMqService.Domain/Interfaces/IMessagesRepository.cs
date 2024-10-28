using RabbitMqService.Domain.Models;

namespace RabbitMqService.DataAccess.Repositories
{
    public interface IMessagesRepository
    {
        Task<long> CreateAsync(Model.Message message);
        Task<long> UpdateStatusToTransferred(long messageId);
    }
}