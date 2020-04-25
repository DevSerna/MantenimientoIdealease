using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GF.MantenimientoIdealease.Data.Models
{
    public class UploadedFileDTO
    {
        public string Name { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
        public Int64 Size { get; set; }
    }
}
