﻿using System.ComponentModel.DataAnnotations;

namespace ECommerce.backend.Entities
{
    public class Country
    {
        public int Id { get; init; }

        [Display(Name = "Pais")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public required string Name { get; init; }
        public ICollection<State>? States { get; init;}
    }
}