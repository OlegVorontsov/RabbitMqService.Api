using Newtonsoft.Json;
using RabbitMqService.DataAccess.Repositories;
using static RabbitMqService.Domain.Models.Model;
using System.Text;
using System.Xml.Serialization;

namespace RabbitMqService.Application.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessagesRepository _messagesRepository;
        public MessageService(IMessagesRepository messagesRepository)
        {
            _messagesRepository = messagesRepository;
        }
        public async Task<long> ProcessMessage(Message newMessage)
        {
            await AddMessageToDb(newMessage);
            //var xml = ConvertToXml(newMessage);
            //await SendToApi(xml);
            return await UpdateStatusToTransferred(newMessage.Request.Id);
        }

        // SaveToDatabase
        public async Task<long> AddMessageToDb(Message message)
        {
            return await _messagesRepository.CreateAsync(message);
        }
        //UpdateStatusInDb
        public async Task<long> UpdateStatusToTransferred(long requestId)
        {
            return await _messagesRepository.UpdateStatusToTransferred(requestId);
        }

        // ConvertToXml
        public string ConvertToXml(Message newMessage)
        {
            var xmlSerializer = new XmlSerializer(typeof(Message));
            using (var stringWriter = new StringWriter())
            {
                xmlSerializer.Serialize(stringWriter, newMessage);
                return stringWriter.ToString();
            }
        }

        // SendToApi
        public async Task SendToApi(string xml)
        {
            using (var client = new HttpClient())
            {
                var content = new StringContent(xml, Encoding.UTF8, "application/xml");
                var response = await client.PostAsync("https://some-api-url.com/endpoint", content);
                response.EnsureSuccessStatusCode();
            }
        }
    }
}