using DesignPattern.Decorator.DAL;

namespace DesignPattern.Decorator.DecoratorPattern2
{
    public class EncryptoBySubjectDecorator(ISendMessage _sendMessage, Context _context) : Decorator(_sendMessage)
    {
        public void SendMessageByEncryptoSubject(Message message)
        {
            string data = message.MessageSubject;
            char[] chars = data.ToCharArray();
            string encrypted = "";
            foreach(var item in chars)
            {
                encrypted += Convert.ToChar(item + 3).ToString();
            }
            message.MessageSubject = encrypted;
            _context.Messages.Add(message);
            _context.SaveChanges();
        }

        public override void SendMessage(Message message)
        {
            SendMessageByEncryptoSubject(message);
        }
    }
}
