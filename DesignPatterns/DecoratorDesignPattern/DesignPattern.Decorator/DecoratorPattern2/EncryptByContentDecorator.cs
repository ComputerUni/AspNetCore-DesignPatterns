using DesignPattern.Decorator.DAL;

namespace DesignPattern.Decorator.DecoratorPattern2
{
    public class EncryptByContentDecorator(ISendMessage _sendMessage, Context _context) : Decorator(_sendMessage)
    {
        public void SendMessageByEncryptContent(Message message)
        {
            message.MessageSender = "Takım Lideri";
            message.MessageReceiver = "Yazılım Ekibi";
            message.MessageContent = "Saat 17.00'de publish yapılacak.";
            message.MessageSubject = "Publish";
            string data = message.MessageSubject;
            char[] chars = data.ToCharArray();
            string encrypted = "";
            foreach (var item in chars)
            {
                encrypted += Convert.ToChar(item + 3).ToString();
            }
            message.MessageContent = encrypted;
            _context.Messages.Add(message);
            _context.SaveChanges();
        }

        public override void SendMessage(Message message)
        {
            SendMessageByEncryptContent(message);
        }
    }
}
