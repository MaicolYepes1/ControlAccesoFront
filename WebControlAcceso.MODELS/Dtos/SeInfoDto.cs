using System.Collections.Generic;

namespace WebControlAcceso.MODELS.Dtos
{
    public class SeInfoDto
    {
        public List<UsserInfoDto> UserInfo { get; set; }
        public List<DependencyDto> Dependency { get; set; }
        public List<UserCardNumberGroupDatumDto> InfoTarjet { get; set; }
        public List<UserAccessLevelGroupDatumDto> LevelAccess { get; set; }
    }
}
