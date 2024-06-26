﻿using System.ComponentModel.DataAnnotations;

namespace ECommerce.backend.Entities
{
    public class Category
    {
        public int Id { get; init; }

        [Display(Name = "Categoria")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public required string Name { get; init; }
    }
}
