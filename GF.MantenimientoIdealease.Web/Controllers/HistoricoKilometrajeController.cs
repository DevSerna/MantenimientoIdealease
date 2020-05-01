using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GF.TransferUtilities.Api;
using GF.MantenimientoIdealease.Data.Models;
using GF.MantenimientoIdealease.Data.Repositories;
using System.Security.Claims;

namespace GF.MantenimientoIdealease.Web.Controllers
{
    public class HistoricoKilometrajeController : ApiController
    {
        private HistoricoKilometrajeRepository repository;

        public HistoricoKilometrajeController()
        {
            repository = new HistoricoKilometrajeRepository();
        }

        [HttpPost]
        [Route("api/SubirArchivoInterface")]
        public IHttpActionResult SubirArchivoInterface([FromBody] UploadedFileDTO file)
        {

            List<HistoricoKilometrajeDTO> listaResultado = new List<HistoricoKilometrajeDTO>();
            DataResult<List<HistoricoKilometrajeDTO>> response = null;

            ClaimsIdentity claimsIdentity = User.Identity as ClaimsIdentity;
            Claim claim = claimsIdentity.FindFirst(ClaimTypes.Email);

            string emailUsuario = claim == null ? "" : claim.Value;

            try
            {
                listaResultado = repository.ImportarDatosInterface(file, emailUsuario);
                response = DataResultHelper.Done(listaResultado);
            }
            catch (Exception exception)
            {
                response = DataResultHelper.Fail<List<HistoricoKilometrajeDTO>>(exception);
            }

            return Ok(response);

        }

        [HttpPost]
        [Route("api/ConsultarHistorico")]
        public IHttpActionResult ConsultarHistorico()
        {
            List<HistoricoKilometrajeDTO> listaHistoricos = null;

            DataResult<List<HistoricoKilometrajeDTO>> result = null;

            try
            {
                repository = new HistoricoKilometrajeRepository();
                listaHistoricos = repository.GetAll();
                result = DataResultHelper.Done(listaHistoricos);
            }
            catch (Exception ex)
            {
                result = DataResultHelper.Fail<List<HistoricoKilometrajeDTO>>(ex);
            }

            return Ok(result);
        }



    }
}
