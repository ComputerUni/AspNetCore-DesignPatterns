using DesignPattern.Decorator.DAL;

namespace DesignPattern.Decorator.DecoratorPattern
{
    public class CreateNotifier(Context _context) : INotifier
    {
        public void CreateNotify(Notifier notifier)
        {
            _context.Notifiers.Add(notifier);
            _context.SaveChanges();
        }
    }
}
