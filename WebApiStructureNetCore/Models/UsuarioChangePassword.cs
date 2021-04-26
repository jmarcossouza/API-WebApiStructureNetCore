using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiStructureNetCore.Models
{
    public class UsuarioChangePassword
    {
        [Required]
        public string SenhaAtual { get; set; }
        [Required(AllowEmptyStrings = false)]
        [MinLength(8)]
        [MaxLength(84)]
        public string NovaSenha { get; set; }
    }
}
