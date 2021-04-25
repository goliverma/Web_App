using System;
using System.Threading.Tasks;
using demo_models.Table;
using demo_web.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demo_web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository context;

        public AccountController(IAccountRepository context)
        {
            this.context = context;
        }
        [HttpGet]
        public IActionResult RegisterNewUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterNewUser(Account model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var Result = await context.register(model);
                    return RedirectToAction("Login","Account");
                }
                return View(model);
            }
            catch (Exception)
            {
                return Ok();
            }
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View("login");
        }
        [HttpPost]
        public async Task<IActionResult> Login(Account user)
        {
            try{
                if(ModelState.IsValid)
                {
                    if(await context.loginDetails(user) == true)
                    {
                        HttpContext.Session.SetString("UserName", user.username);
                        Account use = await context.find(user.username);
                        HttpContext.Session.SetString("UserId", use.Id.ToString());
                        return RedirectToAction("GetAction", "Movies");
                    }
                    ModelState.AddModelError(string.Empty,"Invalid Login");
                }
                return View(user);
            }
            catch(Exception)
            {
                return Ok();
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("GetAction", "Movies");
        }
    }
}