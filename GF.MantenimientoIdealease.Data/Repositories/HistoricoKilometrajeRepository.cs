using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using GF.MantenimientoIdealease.Data.Models;

namespace GF.MantenimientoIdealease.Data.Repositories
{
    public class HistoricoKilometrajeRepository
    {

        public List<HistoricoKilometrajeDTO> ImportarDatosInterface(UploadedFileDTO file)
        {
            List<HistoricoKilometrajeDTO> listaResultado = new List<HistoricoKilometrajeDTO>();
            DB_MAPRI_Entities context = null;

            try
            {
                context = new DB_MAPRI_Entities();

                XLWorkbook archivoXLSX = GetWoorkbook(file.Data);

                var foo = archivoXLSX.Worksheets;

                IXLRows nonEmptyDataRows = archivoXLSX.Worksheet("Report").RowsUsed();

                foreach (var dataRow in nonEmptyDataRows)
                {
                    //for row number check
                     if (dataRow.RowNumber() >= 6)
                    {
                    //to get column # 3's data
                        var cellx = dataRow.Cell(6);
                        var cell = dataRow.Cell(3).Value;

                        var cell4 = dataRow.Cell(4).Value;
                        var cell5 = dataRow.Cell(5).Value;
                        var cell6 = dataRow.Cell(6).Value;
                    }
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                context?.Dispose();
            }


            return listaResultado;
        }

        private XLWorkbook GetWoorkbook(in byte[] data)
        {
            XLWorkbook woorkbook = null;
            MemoryStream stream = null;

            try
            {
                stream = new MemoryStream(data);
                woorkbook = new XLWorkbook(stream);
            }
            catch (Exception exception)
            {
                woorkbook?.Dispose();
                throw exception;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Flush();
                    stream.Close();
                    stream.Dispose();
                }
            }

            return woorkbook;
        }

        private void ImportBankDetails(in byte[] data)
        {

            XLWorkbook woorkbook = null;

            try
            {
                woorkbook = GetWoorkbook(data);

                var sheet = woorkbook.Worksheet(1);

                IXLRow firstRow = sheet.FirstRowUsed(),
                    lastRow = sheet.LastRowUsed(),
                    row = null;

                int start = firstRow.RowNumber() + 1,
                    end = lastRow.RowNumber(),
                    index;

            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                woorkbook?.Dispose();
            }
        }



    }
}
