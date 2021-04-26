using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiStructureNetCore.Models
{
    public class UsuarioEditModel
    {
        [MinLength(2)]
        [MaxLength(35)]
        public string Nome { get; set; }
        [MinLength(2)]
        [MaxLength(35)]
        public string Sobrenome { get; set; }
    }
}
