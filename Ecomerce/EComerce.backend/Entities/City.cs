using System.ComponentModel.DataAnnotations;

namespace ECommerce.backend.Entities
{
    public class City
    {
        public int Id { get; init; }

        [Display(Name = "Ciudad")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public required string Name { get; init; }
        public int StateId { get; init; }
        public State State { get; init; }
    }
}
