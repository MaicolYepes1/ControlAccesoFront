namespace WebControlAcceso.MODELS.Dtos
{
    public class CustomFieldListGroupDatumDto
    {
        public int Id { get; set; }
        public int CustomFieldId { get; set; }
        public int CustomFieldListGroupDataId { get; set; }
        public int Site { get; set; }
        public string DisplayName { get; set; }
        public int ActualValue { get; set; }
    }
}
