using DesignPattern.ChainOfResponsibility.DAL;
using DesignPattern.ChainOfResponsibility.Models;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibility
{
    public class Treasurer : Employee
    {
        private readonly Context _context;

        public Treasurer(Context context) 
        {
            _context = context;
        }

        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            if(req.Amount <= 100000)
            {
                var customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount.ToString();
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Veznedar - Ayşe Çınar";
                customerProcess.Description = "Para çekme işlemi onaylandı, müşteriye talep ettiği tutar ödendi.";
                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                var customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount.ToString();
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Veznedar - Ayşe Çınar";
                customerProcess.Description = "Para çekme tutarı veznedarın günlük ödeyebileceği limiti aştığı için işlem şube müdür yardımcısına yönlendirildi.";
                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}
