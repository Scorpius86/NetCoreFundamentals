using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCore.Fundamentals.Client.Web.Models
{
    public class UsuarioViewModel
    {
        public int UsuarioId { get; set; }
        public string NombreUsuario { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
    }
}
