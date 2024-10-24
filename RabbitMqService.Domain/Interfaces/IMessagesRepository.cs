using RabbitMqService.Domain.Models;

namespace RabbitMqService.DataAccess.Repositories
{
    public interface IMessagesRepository
    {
        Task<long> Create(Model.Message message);
    }
}