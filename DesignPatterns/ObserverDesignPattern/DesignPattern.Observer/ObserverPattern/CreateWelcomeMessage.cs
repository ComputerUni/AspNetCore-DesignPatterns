using DesignPattern.Observer.DAL;

namespace DesignPattern.Observer.ObserverPattern
{
    public class CreateWelcomeMessage : IObserver
    {
        private readonly Context _context;

        public CreateWelcomeMessage(Context context)
        {
            _context = context;
        }

        public void CreateNewUser(AppUser appUser)
        {
            _context.WelcomeMessages.Add(new WelcomeMessage
            {
                NameSurname = appUser.Name + " " + appUser.Surname,
                Content = "Dergi Bültenimize Kayıt Olduğunuz İçin Çok Teşekkür Ederiz, Dergilerimize Web Sitemizden Ulaşabilirsiniz."
            });

            _context.SaveChanges();
        }
    }
}
