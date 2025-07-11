using InfraKeep.Domain.Categories;
using InfraKeep.Domain.Common;
using InfraKeep.Domain.Employees;
using InfraKeep.Domain.Enums;
using InfraKeep.Domain.EquipmentTemplates;
using InfraKeep.Domain.Locations;

namespace InfraKeep.Domain.TechnicalEquipments
{
    /// <summary>
    /// Техническое средство
    /// </summary>
    public class TechnicalEquipment : Entity
    {
        public int EquipmentTemplateId { get; set; }
        public EquipmentTemplate EquipmentTemplate { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public string? SerialNumber { get; set; }
        public string? InventoryNumber { get; set; }

        public string? InvoiceNumber { get; set; }

        public EquipmentStatus Status { get; set; }
        public string? Note { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
