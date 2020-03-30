using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;


namespace GF.MantenimientoIdealease.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Inicio";
            ViewBag.AppName = System.Configuration.ConfigurationManager.AppSettings["AppName"];

            ClaimsIdentity identity = User.Identity as ClaimsIdentity;
            Claim claim = identity.FindFirst(ClaimTypes.Email);

            string emailUsuario = claim == null ? "" : claim.Value;
            ViewBag.EmailUsuario = emailUsuario;

            return View();
        }
    }
}
