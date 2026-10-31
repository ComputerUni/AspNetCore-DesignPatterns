using DesignPattern.Observer.DAL;

namespace DesignPattern.Observer.ObserverPattern
{
    public class CreateDiscountCode : IObserver
    {
        private readonly Context _context;

        public CreateDiscountCode(Context context)
        {
            _context = context;
        }

        public void CreateNewUser(AppUser appUser)
        {
            _context.Discounts.Add(new Discount
            {
                DiscountCode = "DERGIMART",
                DiscountAmount = 35,
                DiscountCodeStatus = true
            });
            _context.SaveChanges();
        }
    }
}
