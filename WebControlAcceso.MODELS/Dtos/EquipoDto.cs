using System;
using System.Collections.Generic;
using System.Text;

namespace WebControlAcceso.MODELS.Dtos
{
    public class EquipoDto
    {
        public int Id { get; set; }
        public int? IdVisitante { get; set; }
        public string Modelo { get; set; }
        public string Serial { get; set; }
        public string Marca { get; set; }
        public string Detalle { get; set; }
        public string Color { get; set; }
    }
}
