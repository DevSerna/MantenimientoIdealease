//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GF.MantenimientoIdealease.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class T_Ihmn
    {
        public int Id { get; set; }
        public string VIN { get; set; }
        public System.DateTime Fecha { get; set; }
        public int Kilometros { get; set; }
        public Nullable<int> Horas { get; set; }
        public Nullable<int> Minutos { get; set; }
        public string Accion { get; set; }
        public System.DateTime CreationDate { get; set; }
        public Nullable<System.DateTime> LastUpdateDate { get; set; }
        public Nullable<System.DateTime> DeleteDate { get; set; }
        public string CreationUser { get; set; }
        public string LastUpdateUser { get; set; }
        public string DeleteUser { get; set; }
    }
}
