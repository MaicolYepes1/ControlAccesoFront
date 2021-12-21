using System.Collections.Generic;
using WebControlAcceso.MODELS.Constants;

namespace WebControlAcceso.MODELS.Dtos
{
    public class DependencyDto
    {
        public List<CustomFieldGroupData> Area { get; set; }
        public List<CustomFieldGroupData> Identificacion { get; set; }
        public List<CustomFieldGroupData> Dependencia { get; set; }
    }
}
