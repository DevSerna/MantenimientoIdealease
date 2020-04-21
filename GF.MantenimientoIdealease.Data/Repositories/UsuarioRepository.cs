using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GF.MantenimientoIdealease.Data.Models;
using GF.TransferUtilities.Api;

namespace GF.MantenimientoIdealease.Data.Repositories
{
    public class UsuarioRepository
    {

        /// <summary>
        /// </summary>
        public UsuarioDTO Login(UsuarioDTO usuario)
        {

            if (string.IsNullOrEmpty(usuario.Email) || string.IsNullOrEmpty(usuario.Password))
            {
                Exception excepcion = new Exception("Usuario o contraseña inválidos.");
                excepcion.TryAddInfo(ParameterTypes.Title, "Error al iniciar sesión.");
                throw excepcion;
            }
            if (string.IsNullOrWhiteSpace(usuario.Email) || string.IsNullOrWhiteSpace(usuario.Password))
            {
                Exception excepcion = new Exception("Usuario o contraseña inválidos.");
                excepcion.TryAddInfo(ParameterTypes.Title, "Error al iniciar sesión.");
                throw excepcion;
            }
            if (!new EmailAddressAttribute().IsValid(usuario.Email))
            {
                Exception excepcion = new Exception("El usuario no es un correo electrónico válido.");
                excepcion.TryAddInfo(ParameterTypes.Title, "Error al iniciar sesión.");
                throw excepcion;
            }

            DB_MAPRI_Entities context = null;
            UsuarioDTO usuarioEncontrado = null;
            T_Usrs usuarioResult = null;

            try
            {
                context = new DB_MAPRI_Entities();

                usuarioResult = context.T_Usrs.AsParallel().FirstOrDefault(
                    e => e.Email == usuario.Email.ToLower() && e.Password == usuario.Password && e.DeleteDate == null);

                if (usuarioResult == null)
                {
                    Exception excepcion = new Exception("No existe un usuario registrado con esos datos.");
                    excepcion.TryAddInfo(ParameterTypes.Title, "Error al iniciar sesión.");
                    throw excepcion;
                }

                usuarioEncontrado = UsuarioDTO.EntityToDTO(usuarioResult);

            }
            catch (Exception exception)
            {

                throw exception;
            }
            finally
            {
                context?.Dispose();
            }

            return usuarioEncontrado;

        }

    }
}
