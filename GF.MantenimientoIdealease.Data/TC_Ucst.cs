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
    
    public partial class TC_Ucst
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TC_Ucst()
        {
            this.TC_Anpc = new HashSet<TC_Anpc>();
        }
    
        public int Id { get; set; }
        public string NombreCliente { get; set; }
        public bool Activo { get; set; }
        public string Accion { get; set; }
        public System.DateTime CreationDate { get; set; }
        public Nullable<System.DateTime> LastUpdateDate { get; set; }
        public Nullable<System.DateTime> DeleteDate { get; set; }
        public string CreationUser { get; set; }
        public string LastUpdateUser { get; set; }
        public string DeleteUser { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TC_Anpc> TC_Anpc { get; set; }
    }
}
