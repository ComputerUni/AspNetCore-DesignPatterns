using DesignPattern.Decorator.DAL;

namespace DesignPattern.Decorator.DecoratorPattern
{
    public class MailDecorator(INotifier _notifier, Context _context) : Decorator(_notifier)
    {
        public void SendMailNotify(Notifier notifier)
        {
            notifier.NotifierSubject = "Günlük Sabah Toplantısı";
            notifier.NotifierCreator = "Scrum Master";
            notifier.NotifierChannel = "Gmail-Outlook";
            notifier.NotifierType = "Private Team";
            _context.Notifiers.Add(notifier);
            _context.SaveChanges();
        }

        public override void CreateNotify(Notifier notifier)
        {
            base.CreateNotify(notifier);
            SendMailNotify(notifier);
        }
    }
}
