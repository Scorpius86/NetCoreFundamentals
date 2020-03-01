using System;
using System.Collections.Generic;

namespace Galaxy.EF.CodeFirst.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            ComentarioUsuarioIdActualizacionNavigations = new HashSet<Comentario>();
            ComentarioUsuarioIdCreacionNavigations = new HashSet<Comentario>();
            ComentarioUsuarioIdPropietarioNavigations = new HashSet<Comentario>();
            PostUsuarioIdActualizacionNavigations = new HashSet<Post>();
            PostUsuarioIdCreacionNavigations = new HashSet<Post>();
            PostUsuarioIdPropietarioNavigations = new HashSet<Post>();
        }

        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }

        public virtual ICollection<Comentario> ComentarioUsuarioIdActualizacionNavigations { get; set; }
        public virtual ICollection<Comentario> ComentarioUsuarioIdCreacionNavigations { get; set; }
        public virtual ICollection<Comentario> ComentarioUsuarioIdPropietarioNavigations { get; set; }
        public virtual ICollection<Post> PostUsuarioIdActualizacionNavigations { get; set; }
        public virtual ICollection<Post> PostUsuarioIdCreacionNavigations { get; set; }
        public virtual ICollection<Post> PostUsuarioIdPropietarioNavigations { get; set; }
    }
}