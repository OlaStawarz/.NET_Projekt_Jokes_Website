/*====================================================================================
                                        REJESTRACJA                                  |
Do rejestracji użyta jest biblioteka AutoMapper. Mapowanie w tym przypadku służy nam |
do zmapowania email'a na nazwę użytkownika, która będzie wykorzystywana w przypadku  |
rejestracji. Wynika to z formularza rejestracyjnego.                                 |
Rejestracja tworzy użytkownika poprzez funkcję CreateAsync obiektu UserMenager.      |
 ====================================================================================*/
/*====================================================================================
                                       LOGIN                                         |
Gdy użytkownik użyje funkcji Zarejestruj metody UserMenager oraz SignInMenager       |
zostają wstrzykowane do kontrolera. Jeżeli model jest prawidłowy to używamy metody   |
FindByEmailAsync by zwrócić użytkownika przez email. Jeżeli użytkownik istnieje, to  |
tworzony jest obiekt ClaimsIdentity. Następuje logowanie poprzez SignInAsync.        |
====================================================================================*/
/*====================================================================================
                                       RETURN                                        |
Jest to zabezpieczenie wynikające z ról. Mianowicie - w programie są dwie role,      |
czyli użytkownik oraz admin. Jeżeli użytkownik chce przejść do akcji, które są dla   |
niego nieuprawnione - zostanie on przekierowany na stronę główną. Jeżeli jednak URL  |
zgadza się z lokalnym, to zostanie przekierowany na żądaną stronę.                   |
====================================================================================*/




using AutoMapper;
using IdentityByExamples.Controllers;
using Jokes_Website.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Jokes_Website.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger _logger;
        public AccountController(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, ILogger<AccountController> logger)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }


        [HttpGet]
        public IActionResult Register()
        {
            _logger.LogDebug("DEBUG: Przechodzi do widoku rejestracji!");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegistration userModel)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("ERROR: Nieprawidłowe powiązanie wartości przychodzacych z żadania do modelu!!");
                return View(userModel);
            }

            var user = _mapper.Map<User>(userModel);

            var result = await _userManager.CreateAsync(user, userModel.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    _logger.LogError("ERROR: Rejestracja zakończona niepowodzeniem!");
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return View(userModel);
            }

            _logger.LogDebug("DEBUG: Rejestracja zakończona powodzeniem!");
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            _logger.LogDebug("DEBUG: Przechodzi do widoku loginu!");
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLogin userModel, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("ERROR: Nieprawidłowe powiązanie wartości przychodzacych z żadania do modelu!!");
                return View(userModel);
            }

            var result = await _signInManager.PasswordSignInAsync(userModel.Email, userModel.Password, userModel.RememberMe, false);
            if (result.Succeeded)
            {
                _logger.LogDebug("DEBUG: Login zakończony powodzeniem!");
                return Return(returnUrl);
            }
            else
            {
                _logger.LogError("ERROR: Login zakończony niepowodzeniem!");
                ModelState.AddModelError("", "Nieprawidłowy login lub hasło");
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            _logger.LogDebug("DEBUG: Wylogowanie zakończone powodzeniem!");
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        private IActionResult Return(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            else
                return RedirectToAction(nameof(ApiController.Index), "Api");
        }
    }
}