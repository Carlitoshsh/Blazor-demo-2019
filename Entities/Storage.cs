using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTest.Entities
{
    public class Storage
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }
        
        [Required]
        public DateTime LastUpdate { get; set; }

        [Required]
        public int PartialQuantity { get; set; }

        //Relación con produtos (Product)
        public string ProductId { get; set; }
        public Product Product { get; set; }


        //Relacion con bodegas (Wherehouse)
        public string WarehouseId { get; set; }
        public Warehouse Warehouse { get; set; }


        //Relación con movimientos (InputOutput)
        public ICollection<InputOutput> InputOutputs { get; set; }
    }
}
