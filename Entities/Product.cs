using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTest.Entities
{
    public class Product
    {
        [Key]
        [StringLength(10)]
        public string Id { get; set; }
       
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        [StringLength(600)]
        public string Description { get; set; }

        public int TotalQuantity { get; set; }

        public string CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Storage> Storages { get; set; }
    }
}
