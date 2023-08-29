using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models {
    public class OrderLine {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public virtual Order? Order { get; set; }
        [StringLength(30)]public string Product { get; set; }
        [StringLength(80)]public string Description { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "Decimal(11,2)")]public decimal Price { get; set; }
    }
}
