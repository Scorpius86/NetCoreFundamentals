using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Fundamentals.Client.Web.Models
{
    public class PostViewModel
    {
        public int PostId { get; set; }
        public string Titulo { get; set; }
        public string Contenido { get; set; }
        public int UsuarioIdPropietario { get; set; }
        public int UsuarioIdCreacion { get; set; }
        [Display(Name ="Fecha de creación")]
        public DateTime FechaCreacion { get; set; }
        public int UsuarioIdActualizacion { get; set; }
        [Display(Name = "Fecha de actualización")]
        public DateTime FechaActualizacion { get; set; }

        [Display(Name = "Usuario de actualización")]
        public UsuarioViewModel UsuarioActualizacion { get; set; }
        [Display(Name = "Usuario de creación")]
        public UsuarioViewModel UsuarioCreacion { get; set; }
        [Display(Name = "Propietario")]
        public UsuarioViewModel UsuarioPropietario { get; set; }
    }
}
