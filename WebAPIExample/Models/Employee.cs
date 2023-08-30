using System.ComponentModel.DataAnnotations;

namespace WebAPIExample.Models {
    public class Employee {
        public int ID { get; set; }
        [StringLength(50)]public string Email { get; set; } = String.Empty;
        [StringLength(30)]public string Password { get; set; } = string.Empty;
        public bool Active { get; set; } = true;
        
    }
}
