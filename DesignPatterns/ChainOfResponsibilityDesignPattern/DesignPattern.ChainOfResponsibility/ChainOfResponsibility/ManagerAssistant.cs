using DesignPattern.ChainOfResponsibility.DAL;
using DesignPattern.ChainOfResponsibility.Models;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibility
{
    public class ManagerAssistant : Employee
    {
        private readonly Context _context;

        public ManagerAssistant(Context context, CustomerProcess customerProcess)
        {
            _context = context;
        }

        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            if(req.Amount <= 150000)
            {
                var customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount.ToString();
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Şube Müdür Yardımcısı - Melike Öztürk";
                customerProcess.Description = "Para çekme işlemi onaylandı, müşteriye talep ettiği tutar ödendi.";
                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                var customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount.ToString();
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Şube Müdür Yardımcısı - Melike Öztürk";
                customerProcess.Description = "Para çekme tutarı şube müdür yardımcısının günlük ödeyebileceği limiti aştığı için işlem şube müdürüne yönlendirildi.";
                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}
