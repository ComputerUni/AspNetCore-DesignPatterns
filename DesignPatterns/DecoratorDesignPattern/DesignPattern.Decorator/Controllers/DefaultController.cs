using DesignPattern.Decorator.DAL;
using DesignPattern.Decorator.DecoratorPattern2;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.Decorator.Controllers
{
    public class DefaultController(ISendMessage _sendMessage, Context _context) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(Message message)
        {
            _sendMessage.SendMessage(message);
            return View();
        }


        [HttpGet]
        public IActionResult Index2()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index2(Message message)
        {
            CreateNewMessage createNewMessage = new CreateNewMessage(_context);
            EncryptoBySubjectDecorator encryptoBySubjectDecorator = new EncryptoBySubjectDecorator(createNewMessage, _context);
            encryptoBySubjectDecorator.SendMessageByEncryptoSubject(message);
            return View();
        }

        [HttpGet]
        public IActionResult Index3()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index3(Message message)
        {
            CreateNewMessage createNewMessage = new CreateNewMessage(_context);
            SubjectIDDecorator subjectIDDecorator = new SubjectIDDecorator(createNewMessage, _context);
            subjectIDDecorator.SendMessageIDSubject(message);
            return View();
        }
    }
}
