using GeekShopping.MessageBus;

namespace GeekShopping.Cart.API.RabbitMqSender
{
    public interface IRabbitMqMessageSender
    {
        void SendMessage(BaseMessage baseMessage, string queueName);
    }
}