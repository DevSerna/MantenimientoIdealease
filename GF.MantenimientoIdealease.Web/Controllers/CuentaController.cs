using GF.MantenimientoIdealease.Data.Models;
using GF.MantenimientoIdealease.Data.Repositories;
using GF.TransferUtilities.Api;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace GF.MantenimientoIdealease.Web.Controllers
{
    public class CuentaController : ApiController
    {

        private UsuarioRepository repository;

        public CuentaController()
        {
            repository = new UsuarioRepository();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("LoginWebAPI")]
        public DataResult<UsuarioDTO> Login([FromBody] UsuarioDTO request)
        {
            DataResult<UsuarioDTO> response = null;
            UsuarioDTO usuario;

            try
            {
                usuario = repository.Login(request);

                ClaimsIdentity identity = new ClaimsIdentity(
                    authenticationType: DefaultAuthenticationTypes.ApplicationCookie,
                    nameType: ClaimsIdentity.DefaultNameClaimType,
                    roleType: ClaimsIdentity.DefaultRoleClaimType);

                identity.AddClaim(new Claim(ClaimTypes.Email, request.Email, ClaimValueTypes.Email));

                Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                Authentication.SignIn(identity);

                response = DataResultHelper.Done(usuario);

            }
            catch (Exception exception)
            {

                return DataResultHelper.Fail<UsuarioDTO>(exception);
            }

            return response;

        }

        [Route("TryLogoutWebAPI")]
        public IHttpActionResult Logout()
        {
            Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return Ok();
        }

        private IAuthenticationManager Authentication
        {
            get { return Request.GetOwinContext().Authentication; }
        }



    }
}
