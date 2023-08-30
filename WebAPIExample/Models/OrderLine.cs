using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPIExample.Models {
    public class OrderLine {
        public int ID { get; set; }
        public int Quantity { get; set; }
        public int OrderID { get; set; }
        [JsonIgnore]public virtual Order? Order { get; set; }
        public int ItemID { get; set; }
        public virtual Item? Item { get; set; }
        //[StringLength(30)]public string Product { get; set; }
        //[StringLength(80)]public string Description { get; set; }
        //[Column(TypeName = "Decimal(11,2)")]public decimal Price { get; set; }
    }
}
