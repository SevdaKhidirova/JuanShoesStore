using juan.Models;
using juan.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace juan.Controllers
{
    public class AccauntController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        public AccauntController(UserManager<AppUser> _userManager, SignInManager<AppUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            AppUser newUser = new AppUser
            {
                Name = viewModel.Name,
                Surname = viewModel.Surname,
                Age = viewModel.Age,
                Email = viewModel.Email,
                UserName = viewModel.Email.Split("@")[0]
               
            };

            IdentityResult result = await userManager.CreateAsync(newUser, viewModel.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(viewModel);
            }

            await signInManager.SignInAsync(newUser, false);
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            AppUser logginUser = await userManager.FindByEmailAsync(viewModel.Email);
            if (logginUser == null)
            {
                ModelState.AddModelError("", "Email or Password wrong");
                return View(logginUser);
            }

            Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(logginUser, viewModel.Password, viewModel.StayLoggedIn, false);

            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("", "After 30 seconds you can try agan");
                }
                else
                {
                   ModelState.AddModelError("", "Email or Password wrong");
                }
                return View(viewModel);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
