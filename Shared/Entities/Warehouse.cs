using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTest.Shared.Entities
{
    public class Warehouse
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        //Relación con almacenamiento (StorageEntity)
        public ICollection<Storage> Storages { get; set; }
    }
}
