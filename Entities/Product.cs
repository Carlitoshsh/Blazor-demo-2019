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
        [MinLength(3, ErrorMessage = "El mínimo requerido es 3 caracteres")]
        [MaxLength(10, ErrorMessage = "El máximo requerido es 10")]
        [Required(ErrorMessage = "Este campo es requerido")]
        public string Id { get; set; }

        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(600)]
        public string Description { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_\.-]+@([a-zA-Z0-9-]+\.)+[a-zA-Z]{2,6}",
         ErrorMessage = "No es un email permitido.")]
        public string Email { get; set; }

        public int TotalQuantity { get; set; }

        public string CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<Storage> Storages { get; set; }
    }
}
