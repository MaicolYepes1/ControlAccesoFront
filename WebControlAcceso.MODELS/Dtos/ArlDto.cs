using System;
using System.Collections.Generic;
using System.Text;

namespace WebControlAcceso.MODELS.Dtos
{
    public class ArlDto
    {
        public int Id { get; set; }
        public int? IdVisitante { get; set; }
        public string Documento { get; set; }
        public string FechaExpiracion { get; set; }
        public string Detalle { get; set; }
    }
}
