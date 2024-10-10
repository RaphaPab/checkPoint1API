using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace checkPoint1.Models
{
    [Table("TB_PLANO_SAUDE_CP")]
    
    public class PlanoSaude
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string NomePlano { get; set; }

        [Required]
        [StringLength(200)]
        public string Cobertura { get; set; }

        
        
        public List<PacientePlanoSaude> PacientePlanosSaude { get; set; }

        public PlanoSaude() { }

        public PlanoSaude(int id, string nomePlano, string cobertura)
        {
            Id = id;
            NomePlano = nomePlano;
            Cobertura = cobertura;
        }
    }
}
   