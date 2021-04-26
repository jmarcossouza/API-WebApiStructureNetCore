using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiStructureNetCore.Models
{
    public class UsuarioNewModel
    {
        [Required]
        [MaxLength(254)]
        [EmailAddress(ErrorMessage = "E-mail com formato inválido.")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MinLength(8)]
        [MaxLength(84)]
        public string Senha { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MinLength(2)]
        [MaxLength(35)]
        public string Nome { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MinLength(2)]
        [MaxLength(35)]
        public string Sobrenome { get; set; }
    }
}
