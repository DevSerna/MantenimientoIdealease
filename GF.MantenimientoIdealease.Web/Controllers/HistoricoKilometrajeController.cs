using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GF.TransferUtilities.Api;
using GF.MantenimientoIdealease.Data.Models;
using GF.MantenimientoIdealease.Data.Repositories;

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

            try
            {
                listaResultado = repository.ImportarDatosInterface(file);
                response = DataResultHelper.Done(listaResultado);
            }
            catch (Exception exception)
            {
                response = DataResultHelper.Fail<List<HistoricoKilometrajeDTO>>(exception);
            }

            return Ok(response);

        }


    }
}
