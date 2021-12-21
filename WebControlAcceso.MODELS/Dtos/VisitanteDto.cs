using System;
using System.Collections.Generic;
using System.Text;

namespace WebControlAcceso.MODELS.Dtos
{
    public class VisitanteDto
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Identificacion { get; set; }
        public string TipoDoc { get; set; }
        public string FExpedicionDoc { get; set; }
        public string Rh { get; set; }
        public string CodigoTarjeta { get; set; }
        public string Profesion { get; set; }
        public string Genero { get; set; }
        public string Correo { get; set; }
        public string Detalle { get; set; }
        public string TipoVisitante { get; set; }
        public string Empresa { get; set; }
        public string Foto { get; set; }
        public string Firma { get; set; }
        public bool EstadoAcceso { get; set; }
        public string Responsable { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }
        public List<EquipoDto> Equipos { get; set; }
        public List<ArlDto> Arl { get; set; }
        public List<IncidenteDto> Incidentes { get; set; }
        public List<VehiculosVisitanteDto> Vehiculos { get; set; }
    }
}
