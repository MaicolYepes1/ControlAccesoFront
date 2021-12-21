using System.Collections.Generic;

namespace WebControlAcceso.MODELS.Dtos
{
    public class InfoDto
    {
        public List<UserCustomFieldGroupDatumDto> Customs { get; set; }
        public List<UserCardNumberGroupDatumDto> Cards { get; set; }
        public List<UserAccessLevelGroupDatumDto> Access { get; set; }
    }
}
