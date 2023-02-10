using CompanyCatalogue.DataAccess;
using CompanyCatalogue.Helpers;
using CompanyCatalogue.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CompanyCatalogue.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IdentityDbContext _identityDbContext;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IdentityDbContext identityDbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _identityDbContext = identityDbContext;
        }
 
        public IActionResult Login()
        {
            var response = new LoginModel();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid) return View(loginModel);

            var user = await _userManager.FindByEmailAsync(loginModel.Email);

            if(user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginModel.Password);
                if(passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginModel.Password, true, false);
                    if(result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    TempData["Error"] = "Wrong credentials. Please try again";
                    return View(loginModel);
                }
            }
            TempData["Error"] = "Wrong credentials. Please try again";
            return View(loginModel);

        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            if(!ModelState.IsValid) return View(registerModel);

            var user = await _userManager.FindByEmailAsync(registerModel.Email);

            if(user != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(registerModel);
            }

            var newUser = new AppUser()
            {
                Email = registerModel.Email,
                UserName = registerModel.Email,
            };

            if(registerModel.Password != registerModel.ConfirmPassword)
            {
                TempData["Error"] = "Password does not match";
                return View(registerModel);
            }

            var newUserResponse = await _userManager.CreateAsync(newUser, registerModel.Password);
            if(newUserResponse.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            } else
            {
                TempData["Error"] = newUserResponse.Errors.First().Description;
                return View(registerModel);
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
