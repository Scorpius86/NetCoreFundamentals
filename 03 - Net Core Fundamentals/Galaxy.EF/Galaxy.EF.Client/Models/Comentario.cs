using System;
using System.Collections.Generic;

namespace Galaxy.EF.Client.Models
{
    public partial class Comentario
    {
        public int ComentarioId { get; set; }
        public int PostId { get; set; }
        public string Contenido { get; set; }
        public int UsuarioIdPropietario { get; set; }
        public int UsuarioIdCreacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int UsuarioIdActualizacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public DateTime SysStartTime { get; set; }
        public DateTime SysEndTime { get; set; }

        public virtual Post Post { get; set; }
        public virtual Usuario UsuarioIdActualizacionNavigation { get; set; }
        public virtual Usuario UsuarioIdCreacionNavigation { get; set; }
        public virtual Usuario UsuarioIdPropietarioNavigation { get; set; }
    }
}
