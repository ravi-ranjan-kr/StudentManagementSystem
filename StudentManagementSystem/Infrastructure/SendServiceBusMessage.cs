using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Infrastructure
{
    public class SendServiceBusMessage
    {
        private readonly ILogger _logger;

        public IConfiguration _configuration;

        public ServiceBusClient _client;
        public ServiceBusSender _clientSender;

        public SendServiceBusMessage(IConfiguration configuration, ILogger<SendServiceBusMessage> logger)
        {
            _logger = logger;
            var _serviceBusConnectionString = _configuration["ServiceBusConnectionString"];
            string queueName = _configuration["QueueName"];
            _client = new ServiceBusClient(_serviceBusConnectionString);
            _clientSender = _client.CreateSender(queueName);
        }

        public async Task sendServiceBusMessage(ServiceBusMessageData serviceBusMessage)
        {
            var messagePayload = JsonSerializer.Serialize(serviceBusMessage);
            ServiceBusMessage message = new ServiceBusMessage(messagePayload);
            try
            {
                await _clientSender.SendMessageAsync(message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}
