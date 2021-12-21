using System;
using System.Collections.Generic;
using System.Text;
using WebControlAcceso.MODELS.Constants;

namespace WebControlAcceso.MODELS.Dtos
{
    public class UserDto
    {
        public UserDto()
        {
            Token = string.Empty;
            Lista = new List<Roles>();
        }
        public string Foto { get; set; }
        public string Usuario { get; set; }
        public string Token { get; set; }
        public DateTime? TokenExpiracion { get; set; }
        public List<Roles> Lista { get; set; }
    }
}
