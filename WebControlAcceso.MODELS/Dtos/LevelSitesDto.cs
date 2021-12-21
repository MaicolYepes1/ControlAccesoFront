using System;
using System.Collections.Generic;
using System.Text;

namespace WebControlAcceso.MODELS.Dtos
{
    public class LevelSitesDto
    {
        public int AccessLevelID { get; set; }
        public int SiteId { get; set; }
        public string Name { get; set; }
        public string Name2 { get; set; }
        public int AccessLevelDoor { get; set; }
        public int AccessLevelDoorGroup { get; set; }
        public DateTime LastModified { get; set; }
        public bool LastModifiedValid { get; set; }
        public int AccessLevelFloor { get; set; }
        public int AccessLevelFloorGroup { get; set; }
        public int AccessLevelElevatorGroup { get; set; }
        public int AccessLevelMenuGroup { get; set; }
        public int AccessLevelAreaGroup { get; set; }
        public int AccessLevelAreaGroup2 { get; set; }
        public decimal OperatingSchedule { get; set; }
        public int AccessLevelPGMGroup { get; set; }
        public int TimeToActivatePGM { get; set; }
        public bool ReaderAccessActivatesPGM { get; set; }
        public bool KeypadAccessActivatesPGM { get; set; }
        public int AccessLevelPGM { get; set; }
        public decimal RecordGroup { get; set; }
        public bool HasFullAccess { get; set; }
        public bool ReadOnly { get; set; }
        public DateTime Created { get; set; }
        public string LastOperator { get; set; }
        public int SEIndex { get; set; }
        public int AccessLevelSaltoDoor { get; set; }
        public int AccessLevelSaltoDoorGroup { get; set; }
        public int AccessLevelSaltoOutput { get; set; }
        public bool EnableMultiBadgeArming { get; set; }
        public bool ActivateOutputUntilAccessLevelExpiry { get; set; }
        public int AccessLevelKabaLockID { get; set; }
        public int AccessLevelKabaLockGroup { get; set; }
        public decimal ElevatorDestinationFloor { get; set; }
        public bool IncludeAllDoors { get; set; }
        public bool IncludeAllFloors { get; set; }
        public bool IncludeAllElevators { get; set; }
        public bool IncludeAllArmingAreas { get; set; }
        public bool IncludeAllDisArmingAreas { get; set; }
        public int MyAccessLevelKeyWatcherKeysProperty { get; set; }
        public int AccessLevelKeyWatcherKeysGroup { get; set; }
        public string SchindlerTemplate { get; set; }
        public string Commands { get; set; }
        public bool EnableUsageRestriction { get; set; }
        public int UsageLimit { get; set; }
        public int ResetPeriod { get; set; }
        public int ResetPeriodType { get; set; }
        public bool EnableDoorTypeOverride { get; set; }
        public bool ToggleAccessLevelOutput { get; set; }
    }
}
