using System.ComponentModel.DataAnnotations.Schema;

namespace checkPoint1.Models
{
    [Table("TB_PACIENTE_PLANO_CP")]
    public class PacientePlanoSaude
    {
        public int PacienteId { get; set; }
        public int PlanoSaudeId { get; set; }
        public Paciente Paciente { get; set; }
        public PlanoSaude PlanoSaude { get; set; }


        public PacientePlanoSaude(int pacienteId, int planoSaudeId)
        {
            PacienteId = pacienteId;
            PlanoSaudeId = planoSaudeId;
        }
        public PacientePlanoSaude() { }
    }

}
