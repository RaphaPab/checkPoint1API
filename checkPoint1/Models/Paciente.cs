using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace checkPoint1.Models
{
    [Table("TB_PACIENTE_CP")]
    public class Paciente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string NomeCompleto { get; set; }

        [Required]
        [Column(TypeName = "DATE")]
        public DateTime DataNascimento { get; set; }

        [Required]
        [StringLength(11)]
        public string CPF { get; set; }

        [Required]
        [StringLength(200)]
        public string Endereco { get; set; }

        [Required]
        [StringLength(15)]
        public string Telefone { get; set; }

        
        public List<PlanoSaude>? PlanosSaude { get; set; } 

        public ICollection<PacientePlanoSaude>? PacientePlanosSaude { get; set; }

        public Paciente() { }

        public Paciente(int id, string nomeCompleto, DateTime dataNascimento, string cpf, string endereco, string telefone)
        {
            Id = id;
            NomeCompleto = nomeCompleto;
            DataNascimento = dataNascimento;
            CPF = cpf;
            Endereco = endereco;
            Telefone = telefone;
        }
    }
}