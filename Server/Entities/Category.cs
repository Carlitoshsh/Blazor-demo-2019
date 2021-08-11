using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorTest.Server.Entities {
    public class Category
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
