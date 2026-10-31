using DesignPattern.Observer.DAL;

namespace DesignPattern.Observer.ObserverPattern
{
    public class CreateMagazineAnnouncement : IObserver
    {
        private readonly Context _context;

        public CreateMagazineAnnouncement(Context context)
        {
            _context = context;
        }


        public void CreateNewUser(AppUser appUser)
        {
            _context.UserProcesses.Add(new UserProcess
            {
                NameSurname = appUser.Name + " " + appUser.Surname,
                Magazine = "Bilim Dergisi",
                Content = "Bilim Dergimizin Mart Sayısı 1 Mart'ta Evinize Ulaştırılacaktır, Konular Jüpiter Gezegeni ve Mars Olacaktır."
            });
            _context.SaveChanges();
        }
    }
}
