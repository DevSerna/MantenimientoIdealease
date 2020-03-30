using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GF.MantenimientoIdealease.Data.Models
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public System.DateTime CreationDate { get; set; }
        public Nullable<System.DateTime> LastUpdate { get; set; }
        public Nullable<System.DateTime> DeleteDate { get; set; }
        public int CreationUser { get; set; }
        public Nullable<int> LastUpdateUser { get; set; }
        public Nullable<int> DeleteUser { get; set; }

        public static UsuarioDTO EntityToDTO(TC_uee entity)
        {
            UsuarioDTO dto = new UsuarioDTO()
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                Apellidos = entity.Apellidos,
                Email = entity.Email,
                Password = entity.Password,
                CreationDate = entity.CreationDate,
                LastUpdate = entity.LastUpdate,
                DeleteDate = entity.DeleteDate,
                LastUpdateUser = entity.LastUpdateUser,
                DeleteUser = entity.DeleteUser
            };

            return dto;
        }
    }
}
