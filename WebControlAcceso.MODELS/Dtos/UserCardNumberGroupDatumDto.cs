using System;
using System.Collections.Generic;
using System.Text;

namespace WebControlAcceso.MODELS.Dtos
{
    public class UserCardNumberGroupDatumDto
    {
        public int UserId { get; set; }
        public int UserCardNumberGroupDataId { get; set; }
        public int Site { get; set; }
        public string CardNumber { get; set; }
        public string FamilyNumber { get; set; }
        public bool CardDisabled { get; set; }
        public DateTime? ExpiritDate { get; set; }
        public DateTime? StartDate { get; set; }
        public bool Init { get; set; }
        public bool End { get; set; }
    }
}
