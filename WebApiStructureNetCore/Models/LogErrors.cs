using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiStructureNetCore.Models
{
    public class LogErrors
    {
        [Key]
        [StringLength(36)]
        [Column(TypeName = "char(36)")]
        public string Id { get; set; }
        [Required]
        [Column(TypeName = "smallint")]
        public short Tipo { get; set; }
        public long? UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        [Required]
        public bool Resolvido { get; set; } = false;
        [Column("Erro", TypeName = "varchar(max)")]
        private string _erro;
        [Required(AllowEmptyStrings = true)]
        [MaxLength(8000)]
        public string Erro
        {
            get => _erro;
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Length > 8000)
                {
                    value = value.Substring(0, 8000);
                }
                _erro = value;
            }
        }
        [Column(TypeName = "datetime2(0)")]
        public DateTime CriadoEm { get; private set; }

        public LogErrors()
        {
            CriadoEm = DateTime.Now;
        }
    }
}
