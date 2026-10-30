using DesignPattern.ChainOfResponsibility.DAL;
using DesignPattern.ChainOfResponsibility.Models;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibility
{
    public class AreaDirector : Employee
    {
        private readonly Context _context;

        public AreaDirector(Context context)
        {
            _context = context;
        }

        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            if (req.Amount <= 400000)
            {
                var customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount.ToString();
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Bölge Direktörü - İrem Tunalı";
                customerProcess.Description = "Para çekme işlemi onaylandı, müşteriye talep ettiği tutar ödendi.";
                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
            }
            else
            {
                var customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount.ToString();
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Bölge Direktörü - İrem Tunalı";
                customerProcess.Description = "Para çekme tutarı bölge direktörünün günlük ödeyebileceği limiti aştığı için işlem gerçekleştirilemedi, müşterinin günlük maksimum çekebileceği tutar 400.000 ₺ olup daha fazlası için birden fazla gün şubeye gelmesi gerekli...";
                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
            }
        }
    }
}
