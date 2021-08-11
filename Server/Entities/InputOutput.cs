using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTest.Server.Entities
{
    public class InputOutput
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public bool IsInput { get; set; }

        //Relación con almacenamiento (StorageEntity)
        public string StorageId { get; set; }
        public Storage Storage { get; set; }
    }
}
