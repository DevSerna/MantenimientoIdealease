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
    
    public partial class TC_Amcn
    {
        public int Id { get; set; }
        public string Empresa { get; set; }
        public string Nombre { get; set; }
        public string Teléfono { get; set; }
        public string Correo { get; set; }
        public bool Activo { get; set; }
        public string Accion { get; set; }
        public System.DateTime CreationDate { get; set; }
        public Nullable<System.DateTime> LastUpdateDate { get; set; }
        public Nullable<System.DateTime> DeleteDate { get; set; }
        public string CreationUser { get; set; }
        public string LastUpdateUser { get; set; }
        public string DeleteUser { get; set; }
    }
}
