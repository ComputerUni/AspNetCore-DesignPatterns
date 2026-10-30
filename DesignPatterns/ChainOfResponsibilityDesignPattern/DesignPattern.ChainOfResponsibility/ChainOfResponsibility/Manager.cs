using DesignPattern.ChainOfResponsibility.DAL;
using DesignPattern.ChainOfResponsibility.Models;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibility
{
    public class Manager : Employee
    {
        private readonly Context _context;
    
        public Manager(Context context)
        {
            _context = context;
        }

        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            if (req.Amount <= 250000)
            {
                var customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount.ToString();
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Şube Müdürü - Hatice Sarı";
                customerProcess.Description = "Para çekme işlemi onaylandı, müşteriye talep ettiği tutar ödendi.";
                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                var customerProcess = new CustomerProcess();
                customerProcess.Amount = req.Amount.ToString();
                customerProcess.Name = req.Name;
                customerProcess.EmployeeName = "Şube Müdürü - Hatice Sarı";
                customerProcess.Description = "Para çekme tutarı şube müdürünün günlük ödeyebileceği limiti aştığı için işlem bölge müdürüne yönlendirildi.";
                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
                NextApprover.ProcessRequest(req);
            }
        }
    }
}
