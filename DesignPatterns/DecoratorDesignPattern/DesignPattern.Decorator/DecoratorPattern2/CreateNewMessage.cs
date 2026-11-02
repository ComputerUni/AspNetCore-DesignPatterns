using DesignPattern.Decorator.DAL;

namespace DesignPattern.Decorator.DecoratorPattern2
{
    public class CreateNewMessage(Context _context) : ISendMessage
    {
        public void SendMessage(Message message)
        {
            _context.Messages.Add(message);
            _context.SaveChanges();
        }
    }
}
