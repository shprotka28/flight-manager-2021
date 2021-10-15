using flight_manager_2021.Models.Login;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using flight_manager_2021.Shared;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Entity;

namespace flight_manager_2021.Controllers
{
    public class LoginController : Controller
    {
        //private readonly SignInManager<IdentityUser> signInManager;

        /*public LoginController(SignInManager<IdentityUser> signInManager)
        {
            this.signInManager = signInManager;
        }*/

        private readonly ConnectionDB _context;

        public LoginController()
        {
            _context = new ConnectionDB();
        }

        public IActionResult Index(LoginViewModel model)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            //await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [HttpGet]
        public IActionResult Login()
        { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _context.Users.FirstAsync(x => x.UserName == model.UserName && x.Password == model.Password);
            }

            return View(model);
        }
    }
}
