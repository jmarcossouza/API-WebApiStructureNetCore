using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiStructureNetCore.Models
{
    public class Usuario : PasswordHasher<Usuario>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        public string Senha { get
            {
                return Senha;
            }
            set
            {
                Senha = HashPassword(this, value);
            }
        }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }
        public DateTime CriadoEm { get
            {
                return CriadoEm;
            }
            private set
            {
                CriadoEm = DateTime.Now;
            }
        }

        public bool verifyPassword(string passToBeVerified)
        {
            return (VerifyHashedPassword(this, Senha, passToBeVerified) == PasswordVerificationResult.Success);
        }

    }
}
