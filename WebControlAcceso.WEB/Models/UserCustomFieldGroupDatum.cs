using System;
using System.Collections.Generic;

#nullable disable

namespace WebControlAcceso.WEB.Models
{
    public partial class UserCustomFieldGroupDatum
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int UserCustomFieldGroupDataId { get; set; }
        public int Site { get; set; }
        public int CustomFieldId { get; set; }
        public int CustomFieldType { get; set; }
        public int CustomFieldNumericalData { get; set; }
        public string CustomFieldTextData { get; set; }
        public DateTime CustomFieldDateTimeData { get; set; }
        public bool? CustomFieldBooleanData { get; set; }
    }
}
