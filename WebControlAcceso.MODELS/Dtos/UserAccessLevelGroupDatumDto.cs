using System;
using System.Collections.Generic;
using System.Text;

namespace WebControlAcceso.MODELS.Dtos
{
    public class UserAccessLevelGroupDatumDto
    {
        public int UserId { get; set; }
        public int Site { get; set; }
        public int UserAccessLevel { get; set; }
        public DateTime? UserAccessLevelStart { get; set; }
        public DateTime? UserAccessLevelEnd { get; set; }
        public string Name { get; set; }
        public bool UserAccessLevelExpire { get; set; }
    }
}
