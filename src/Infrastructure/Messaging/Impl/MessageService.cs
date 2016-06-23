using System;
using Apache.NMS;
using Newtonsoft.Json;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Interfaces;
using Walmart.Assortment.AssortmentOptimizationSystem.Core.Messages;

namespace Walmart.Assortment.AssortmentOptimizationSystem.Infrastructure.Messaging.Impl
{
    public class MessageService : IMessageService
    {
        private readonly IConnection _connection;
        private readonly IMessageProducer _producer;

        public MessageService(IConnection connection, IMessageProducer producer)
        {
            _connection = connection;
            _producer = producer;
        }

        public Guid Send<T>(T message) where T : CapabilityMessage
        {
            // start the connection
            _connection.Start();
            _producer.DeliveryMode = MsgDeliveryMode.Persistent;

            // send message
            _producer.Send(JsonConvert.SerializeObject(message));
            return Guid.NewGuid();
        }
    }
}
