using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ClosedXML.Excel;
using GF.MantenimientoIdealease.Data.Models;

namespace GF.MantenimientoIdealease.Data.Repositories
{
    public class HistoricoKilometrajeRepository
    {

        private Dictionary<string, int> listaColumnasGuardar = new Dictionary<string, int>()
        {
            { "VIN", 0 },
            { "Odometer", 0 },
            { "Hrs", 0 }
        };

        public List<HistoricoKilometrajeDTO> ImportarDatosInterface(UploadedFileDTO file, string usuario)
        {
            List<HistoricoKilometrajeDTO> listaResultado = new List<HistoricoKilometrajeDTO>();
            List<T_Ihmn> datosAgregar = new List<T_Ihmn>();
            DB_MAPRI_Entities context = null;

            int columnasDetectadas = 0;
            int filaInicio = 0;
            DateTime? fechaCreacionArchivo = null;
            bool esFilaFecha = false;

            try
            {

                XLWorkbook archivoXLSX = GetWoorkbook(file.Data);

                IXLRows nonEmptyDataRows = archivoXLSX.Worksheet("Report").RowsUsed();

                foreach (IXLRow dataRow in nonEmptyDataRows)
                {
                    if (columnasDetectadas == listaColumnasGuardar.Count) break;

                    IXLCells cellsUsed = dataRow.CellsUsed();

                    foreach (IXLCell cellItem in cellsUsed)
                    {

                        if (columnasDetectadas == listaColumnasGuardar.Count) break;

                        string valorCelda = cellItem.GetValue<string>().Trim();

                        if (valorCelda == "Created")
                        {
                            esFilaFecha = true;
                            continue;
                        }
                        if (esFilaFecha && fechaCreacionArchivo == null)
                        {
                            double baseDate = cellItem.GetValue<double>();
                            fechaCreacionArchivo = DateTime.FromOADate(baseDate);
                        }

                        int rowNumber = cellItem.Address.RowNumber;
                        int columnNumber = cellItem.Address.ColumnNumber;
                        string value = cellItem.Value.ToString().Trim();

                        if (listaColumnasGuardar.ContainsKey(value))
                        {
                            if (listaColumnasGuardar[value] == 0)
                            {
                                listaColumnasGuardar[value] = columnNumber;
                                if (filaInicio == 0) filaInicio = rowNumber + 1;
                                columnasDetectadas++;
                            }
                        }

                    }

                }

                var dataRows = archivoXLSX.Worksheet("Report").RowsUsed().Where(r => r.RowNumber() >= filaInicio);

                Parallel.ForEach(dataRows, new ParallelOptions { MaxDegreeOfParallelism = 10 }, e => AgregarHistoricoKilometrajeDTO(e, fechaCreacionArchivo, ref listaResultado));

                datosAgregar.AddRange(
                    listaResultado.AsParallel().Select(
                        e => new T_Ihmn() { 
                            VIN = e.VIN,
                            Fecha = e.Fecha,
                            Kilometros = e.Kilometros,
                            Horas = e.Horas,
                            Minutos = e.Minutos,
                            CreationUser = usuario,
                            Accion = "Alta",
                            CreationDate = DateTime.Now
                        })
                    );

                context = new DB_MAPRI_Entities();

                context.T_Ihmn.AddRange(datosAgregar);
                int saved = context.SaveChanges();

                listaResultado.Clear();

                listaResultado.AddRange(
                    datosAgregar.AsParallel().Select(
                        e => new HistoricoKilometrajeDTO()
                        {
                            Id = e.Id,
                            VIN = e.VIN,
                            Fecha = e.Fecha,
                            Kilometros = e.Kilometros,
                            Horas = e.Horas,
                            Minutos = e.Minutos
                        })
                    );

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

        private void AgregarHistoricoKilometrajeDTO(IXLRow dataRow, DateTime? fecha,ref List<HistoricoKilometrajeDTO> listaResultado)
        {
            string vinRAW = dataRow.Cell(listaColumnasGuardar["VIN"]).Value.ToString().Trim();
            string vin = Regex.Replace(vinRAW, "[^a-zA-Z0-9]", "").Replace("-", "").Trim();

            if (vin.Length < 12) return;

            int kilometros = dataRow.Cell(listaColumnasGuardar["Odometer"]).GetValue<int>();
            double horasSerial = dataRow.Cell(listaColumnasGuardar["Hrs"]).GetValue<double>();

            DateTime fechaSerialInicio = DateTime.FromOADate(0);
            DateTime fechaSerial = DateTime.FromOADate(horasSerial);

            TimeSpan timeSpan = fechaSerial - fechaSerialInicio;

            HistoricoKilometrajeDTO item = new HistoricoKilometrajeDTO()
            {
                VIN = vin,
                Fecha = fecha ?? DateTime.Now,
                Kilometros = kilometros,
                Horas = Convert.ToInt32((timeSpan.TotalMinutes - (timeSpan.TotalMinutes % 60))/60),
                Minutos = fechaSerial.Minute % 60,
                CreationUser = "sa"
            };

            lock(listaResultado) listaResultado.Add(item);
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

        public List<HistoricoKilometrajeDTO> GetAll()
        {
            DB_MAPRI_Entities context = null;
            List<HistoricoKilometrajeDTO> listaHistorico = new List<HistoricoKilometrajeDTO>();

            try
            {

                context = new DB_MAPRI_Entities();

                listaHistorico = context.T_Ihmn.AsParallel()
                    .Select(e => new HistoricoKilometrajeDTO()
                    {
                        Id = e.Id,
                        VIN = e.VIN,
                        Fecha = e.Fecha,
                        FechaF = e.Fecha.ToString("MM/dd/yyyy HH:mm"),
                        Kilometros = e.Kilometros,
                        Horas = e.Horas,
                        Minutos = e.Minutos
                    })
                    .OrderBy(e => e.Id)
                    .ToList<HistoricoKilometrajeDTO>();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                context?.Dispose();
            }

            return listaHistorico;
        }

    }
}
