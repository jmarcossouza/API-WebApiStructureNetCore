using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebApiStructureNetCore.Entities
{
    public class Usuario : PasswordHasher<Usuario>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        /// <summary>Quando criando um novo usuário, sempre enviar com valor 0</summary>
        public long Id { get; set; } = 0;
        [Required]
        [MaxLength(254)]
        [Column(TypeName = "varchar")]
        public string Email { get; set; }
        [Column("Senha", TypeName = "varchar")]
        private string _senha;
        [Required]
        [MinLength(8)]
        [MaxLength(84)]
        public string Senha { 
            get => _senha;
            set
            {
                _senha = HashPassword(this, value);
            }
        }
        [Required]
        [MinLength(2)]
        [MaxLength(35)]
        [Column(TypeName = "varchar")]
        public string Nome { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(35)]
        [Column(TypeName = "varchar")]
        public string Sobrenome { get; set; }
        [Column(TypeName = "datetime2(0)")]
        public DateTime CriadoEm { get; private set; }

        public ICollection<LogErrors> LogErrors { get; set; }

        public Usuario()
        {

            CriadoEm = DateTime.Now;
        }

        public bool verifyPassword(string passToBeVerified)
        {
            return (VerifyHashedPassword(this, Senha, passToBeVerified) == PasswordVerificationResult.Success);
        }
    }
}
