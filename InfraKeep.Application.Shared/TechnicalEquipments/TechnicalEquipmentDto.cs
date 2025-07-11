namespace InfraKeep.Application.Shared.TechnicalEquipments
{
    public class TechnicalEquipmentDto
    {
        public string EquipmentTemplate { get; set; }
        public string Employee { get; set; }
        public string Location { get; set; }
        public string Category { get; set; }
        public string SerialNumber { get; set; }
        public string InventoryNumber { get; set; }
        public string InvoiceNumber { get; set; }
        public string Status { get; set; }
        public string Note { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
