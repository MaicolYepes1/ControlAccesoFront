using System;
using System.Collections.Generic;
using System.Text;

namespace WebControlAcceso.MODELS.Constants
{
    public class Roles
    {
        public int Id { get; set; }
        public string Page { get; set; }
        public bool? Activo { get; set; }
        public int? IdUsuario { get; set; }
    }
}
