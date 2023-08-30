using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models {
    public class Item {
        public int ID { get; set; }
        [StringLength(40)] public string Name { get; set; }
        [Column(TypeName ="Decimal(11,2)")]public decimal Price { get; set; }
    }
}
