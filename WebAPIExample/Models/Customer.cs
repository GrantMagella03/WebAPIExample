using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models {
    public class Customer {
        public int ID { get; set; }
        [StringLength(30)]public string Code { get; set; } = string.Empty;
        [StringLength(30)] public string Name { get; set; } = string.Empty;
        [Column(TypeName ="Decimal(11,2)")]public decimal Sales { get; set; }
        public bool Active { get; set; } = true;
    }
}
