using System.ComponentModel.DataAnnotations;

namespace ECommerce.backend.Entities
{
    public class State
    {
        public int Id { get; init; }

        [Display(Name = "Estado")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public required string Name { get; init; }
        public int CountryId { get; init; }
        public Country Country { get; init; }
        public ICollection<City>? Cities { get; init; }
    }
}
