using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseTech.Models
{
    public class Equipment
    {
        public int Id { get; set; }

        public string? PhotoPath { get; set; }

        [Required]
        public int EquipmentTypeId { get; set; }
        public EquipmentType? EquipmentType { get; set; }

        [Required]
        public int ManufacturerId { get; set; }
        public Manufacturer? Manufacturer { get; set; }

        [Required, MaxLength(200)]
        public string Model { get; set; } = string.Empty;

        [Required]
        public int CountryId { get; set; }
        public Country? Country { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
