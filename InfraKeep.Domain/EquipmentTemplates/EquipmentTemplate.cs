using InfraKeep.Domain.Brands;
using InfraKeep.Domain.Common;
using InfraKeep.Domain.Models;
using InfraKeep.Domain.TypeEquipments;

namespace InfraKeep.Domain.EquipmentTemplates
{
    /// <summary>
    /// Шаблон техники
    /// </summary>
    public class EquipmentTemplate : Entity
    {
        public int TypeEquipmentId { get; set; }
        public TypeEquipment TypeEquipment { get; set; }

        public int ModelId { get; set; }
        public Model Model { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        /// <summary>
        /// Средний срок службы
        /// </summary>
        public int? AverageLifetimeMonths { get; set; }
        /// <summary>
        /// Гарантийный срок службы
        /// </summary>
        public int? WarrantyMonths { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string? Description { get; set; }
    }
}
