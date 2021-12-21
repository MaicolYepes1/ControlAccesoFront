using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebControlAcceso.MODELS.Loads;
using WebControlAcceso.SERVICES.Interfaces.Login;

namespace WebControlAcceso.WEB.Controllers.Login
{
    public class LoginController : Controller
    {
        #region Dependencias
        private readonly ILoginService _login;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        #endregion

        #region Constructor
        public LoginController(ILoginService login, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _login = login;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        #endregion

        #region Metodos

        public async Task<IActionResult> Index(string RedirectUrl = null)
        {
            await Get();
            if (_signInManager.IsSignedIn(User))
            {
                return LocalRedirect("/");
            }
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            if (RedirectUrl != null)
            {
                return LocalRedirect("/Login/Index");
            }
            return View(new LoginLoad());
        }

        [HttpGet]
        public async Task<IActionResult> Salir()
        {
            await Get();
            await _signInManager.SignOutAsync();
            HttpContext.Session.Clear();
            HttpContext.Session.Remove(HttpContext.Session.Id);
            Response.Cookies.Delete(".AspNetCore.Antiforgery.kLmeyaPL6YU");
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            var cookies = Request.Cookies.Keys;
            return Redirect("/Login/Index");
        }

        public async Task<IActionResult> Get()
        {
            var res = await _login.GetLogo();
            HttpContext.Session.SetString("Logo", res[1].Descripcion);
            HttpContext.Session.SetString("Icon", res[2].Descripcion);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginLoad model)
        {
            var result = await _login.Authentication(model);
            if (result != null || result.Token != "")
            {
                var claims = new List<Claim>
                {
                    new Claim("Contrasena", model.Pass)
                };
                HttpContext.Session.SetString("Operator", result.Usuario);

                var claimsIdentity = new ClaimsIdentity(
                    claims,
                    IdentityConstants.ApplicationScheme);

                await HttpContext.SignInAsync(
                IdentityConstants.ApplicationScheme,
                new ClaimsPrincipal(claimsIdentity));

                return Redirect("/Visitantes");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Usuario o contraseña incorrectos.");
            }
            return View();

        }
        #endregion
    }
}
