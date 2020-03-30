using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace GF.MantenimientoIdealease.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            ViewBag.Title = "Iniciar Sesión";
            ViewBag.AppName = System.Configuration.ConfigurationManager.AppSettings["AppName"];

            ClaimsIdentity identity = User.Identity as ClaimsIdentity;
            Claim claim = identity.FindFirst(ClaimTypes.Email);

            string emailUsuario = claim == null ? "" : claim.Value;
            ViewBag.EmailUsuario = emailUsuario;
            if (!string.IsNullOrEmpty(emailUsuario)) return RedirectToAction("Index", "Home");

            return View();
        }
    }
}