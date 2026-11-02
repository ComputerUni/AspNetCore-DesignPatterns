using DesignPattern.Decorator.DAL;

namespace DesignPattern.Decorator.DecoratorPattern2
{
    public class SubjectIDDecorator(ISendMessage _sendMessage, Context _context) : Decorator(_sendMessage)
    {
        public void SendMessageIDSubject(Message message)
        {
            if(message.MessageSubject == "1")
            {
                message.MessageSubject = "Toplantı";
            }
            if(message.MessageSubject == "2")
            {
                message.MessageSubject = "Scrum Toplantısı";
            }
            if(message.MessageSubject == "3")
            {
                message.MessageSubject = "Haftalık Değerlendirme";
            } 
            _context.Messages.Add(message);
            _context.SaveChanges();
        }

        public override void SendMessage(Message message)
        {
            SendMessageIDSubject(message);
        }
    }
}
