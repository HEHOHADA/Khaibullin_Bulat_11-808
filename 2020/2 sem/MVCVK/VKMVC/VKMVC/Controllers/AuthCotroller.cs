using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VKMVC.Models;
using VKMVC.ViewModels;

namespace VKMVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<UserModel> userManager;
        private readonly SignInManager<UserModel> signInManager;

        public AuthController(UserManager<UserModel> userManager, SignInManager<UserModel> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                Console.WriteLine(user);
                if (user == null)
                {
                    ModelState.AddModelError("", "Вы не  зарегестрированны");
                    return View();
                }

                var result = await signInManager.PasswordSignInAsync(user.UserName, model.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
                ModelState.AddModelError("", "Что-то пошло не так");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                UserModel user = userManager.Users.FirstOrDefault(u => u.Email == model.Email);

                if (user != null)
                {
                    ModelState.AddModelError("", "Вы уже зарегестрированны");
                }

                Console.WriteLine(model.Email == "bulat1@yandex.ru");
                var result = model.Email == "bulat1@yandex.ru"
                    ?  userManager.CreateAsync(
                        new UserModel {UserName = model.Username, Email = model.Email, isAdmin = true}, model.Password).Result
                    : userManager.CreateAsync(
                        new UserModel {UserName = model.Username, Email = model.Email, isAdmin = false},
                        model.Password).Result;

                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Auth");
                }
                else
                    ModelState.AddModelError("", result.Errors.ToString());
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Auth");
        }
    }
}