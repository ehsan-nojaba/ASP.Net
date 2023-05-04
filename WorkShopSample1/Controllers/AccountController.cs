using FrameWork.Services;
using Microsoft.AspNetCore.Mvc;
using Security.BusinessServiceContract;

namespace WorkShopSample1.Controllers
{
    public class AccountController : Controller
    {
        private IAccountBuss buss;
        private IPasswordHasher passwordHasherBuss;

        public AccountController(IAccountBuss buss, IPasswordHasher passwordHasherBuss)
        {
            this.buss = buss;
            this.passwordHasherBuss = passwordHasherBuss;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Security.DomainModel.DTO.User.Login l)
        {
            var op = buss.Login(l);
            if (!op.Success)
            {
                ViewBag.ErrorMessage = op.Message;
                return View(l);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Security.DomainModel.Model.User u)
        {
            u.RoleId = 2;
            u.Password = passwordHasherBuss.Hash(u.Password);
            buss.Register(u);
            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}