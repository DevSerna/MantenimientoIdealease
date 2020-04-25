using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GF.MantenimientoIdealease.Data.Models
{
    public class HistoricoKilometrajeDTO
    {
        public int Id { get; set; }
        public string VIN { get; set; }
        public System.DateTime Fecha { get; set; }
        public int Kilometros { get; set; }
        public Nullable<int> Horas { get; set; }
        public Nullable<int> Minutos { get; set; }
    }
}
