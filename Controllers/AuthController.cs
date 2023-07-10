using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using User_Lib;
using WebApp.Models;
using WebApp.Models.DTO;
using WebApp.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace WebApp.Controllers
{
   
        public class AuthController : Controller
        {
            private readonly IAuthService _authService;
            public AuthController(IAuthService authService)
            {
                _authService = authService;
            }

            [HttpGet]
            public IActionResult Login()
            {
                LoginRequestDTO obj = new();
                return View(obj);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Login(LoginRequestDTO obj)
            {
            APIResponse response = await _authService.LoginAsync<APIResponse>(obj);
            if (response != null && response.IsSuccess)
            {
                LoginResponseDTO model = JsonConvert.DeserializeObject<LoginResponseDTO>(Convert.ToString(response.Results));

                var identity =new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Name, model.Admin.Admin_Name));
                identity.AddClaim(new Claim(ClaimTypes.Role, model.Admin.Admin_Type));
                var principle = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principle);
                HttpContext.Session.SetString(SD.SessionToken, model.Token);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("CustomError", response.ErrorMessage.FirstOrDefault());
                return View(obj);
            }
        }

            [HttpGet]
            public IActionResult Register()
            {
                return View();
            }


            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Register(RegisterAdmin obj)
            {
                APIResponse result = await _authService.RegisterAsync<APIResponse>(obj);
                if (result != null && result.IsSuccess)
                {
                    return RedirectToAction("Login");
                }
                return View();
            }


            public async Task<IActionResult> Logout()
            {
            await HttpContext.SignOutAsync();
            HttpContext.Session.SetString(SD.SessionToken, "");
            return RedirectToAction("Index", "Home");
        }

            public IActionResult AccessDenied()
            {
                return View();
            }
        }
    }