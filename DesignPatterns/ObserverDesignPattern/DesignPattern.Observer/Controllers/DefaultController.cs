using DesignPattern.Observer.DAL;
using DesignPattern.Observer.Models;
using DesignPattern.Observer.ObserverPattern;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.Observer.Controllers
{
    public class DefaultController(UserManager<AppUser> _userManager, ObserverObject _observerObject) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel model) 
        {
            var appUser = new AppUser()
            {
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                UserName = model.Username,
                District = model.District
            };

            var result = await _userManager.CreateAsync(appUser, model.Password);
            if(result.Succeeded)
            {
                _observerObject.NotifyObserver(appUser);
                return View();
            }
            return RedirectToAction("Index");
        }
    }
}
