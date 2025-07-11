namespace InfraKeep.Application.Shared.EquipmentTemplates
{
    public class EquipmentTemplatesDto
    {
        public string TypeEquipment { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public int AverageLifetimeMonths { get; set; }
        public int WarrantyMonths { get; set; }
        public string Description { get; set; }
    }
}
