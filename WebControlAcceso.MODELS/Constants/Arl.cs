using System;

namespace WebControlAcceso.MODELS.Constants
{
    public class Arl
    {
        public int Id { get; set; }
        public int? IdVisitante { get; set; }
        public DateTime DateExpArl { get; set; }
        public string DetailsArl { get; set; }
        public string ArlPdf { get; set; }
    }
}
