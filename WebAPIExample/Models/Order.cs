using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample.Models {
    public class Order {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        [StringLength(80)]public string Description { get; set; } = string.Empty;
        [Column(TypeName="Decimal(11,2)")]public decimal Total { get; set; }
        [StringLength(30)]public string Status { get; set; } = "NEW";
        public int CustomerID { get; set; }
        public virtual Customer? customer { get; set; }

        public virtual List<OrderLine>? Orderlines { get; set; }
    }
}
