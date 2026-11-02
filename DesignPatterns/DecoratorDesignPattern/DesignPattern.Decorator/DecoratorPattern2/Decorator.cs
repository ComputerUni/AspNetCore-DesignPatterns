using DesignPattern.Decorator.DAL;

namespace DesignPattern.Decorator.DecoratorPattern2
{
    public class Decorator(ISendMessage _sendMessage) : ISendMessage
    {
        virtual public void SendMessage(Message message)
        {
            message.MessageReceiver = "Everybody";
            message.MessageSender = "Admin";
            message.MessageContent = "Merhaba bu bir toplantı mesajıdır.";
            message.MessageSubject = "Toplantı";
            _sendMessage.SendMessage(message);
        }
    }
}
