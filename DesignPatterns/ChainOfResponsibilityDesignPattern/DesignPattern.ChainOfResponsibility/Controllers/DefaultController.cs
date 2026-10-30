using DesignPattern.ChainOfResponsibility.ChainOfResponsibility;
using DesignPattern.ChainOfResponsibility.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.ChainOfResponsibility.Controllers
{
    public class DefaultController : Controller
    {
        private readonly Treasurer _treasurer;
        private readonly ManagerAssistant _managerAssistant;
        private readonly Manager _manager;
        private readonly AreaDirector _areaDirector;

        public DefaultController(Treasurer treasurer, ManagerAssistant managerAssistant, Manager manager, AreaDirector areaDirector)
        {
            _treasurer = treasurer;
            _managerAssistant = managerAssistant;
            _manager = manager;
            _areaDirector = areaDirector;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CustomerProcessViewModel model)
        {
            _treasurer.SetNextApprover(_managerAssistant);
            _managerAssistant.SetNextApprover(_manager);
            _manager.SetNextApprover(_areaDirector);

            _treasurer.ProcessRequest(model);
            return RedirectToAction("Index");
        }
    }
}
