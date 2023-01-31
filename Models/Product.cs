using System.ComponentModel.DataAnnotations;

namespace apiwhitef.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 a 60 caracteres")]
        public string Title { get; set; }

        [MaxLength(60, ErrorMessage = "Este campo deve conter no maximo 1024 caractres")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public int CategoryId { get; set; }
        
        public Category? Category { get; set; }
    }
}