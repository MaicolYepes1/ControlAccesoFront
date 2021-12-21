using System;
using System.Collections.Generic;
using System.Text;

namespace WebControlAcceso.MODELS.Dtos
{
    public class IncidenteDto
    {
        public int Id { get; set; }
        public int? IdVisitante { get; set; }
        public string Asunto { get; set; }
        public string Fecha { get; set; }
        public string Descripcion { get; set; }
    }
}
