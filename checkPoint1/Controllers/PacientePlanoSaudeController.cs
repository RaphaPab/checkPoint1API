// Usings
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using checkPoint1.Data;
using checkPoint1.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Http;


namespace checkPoint1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientePlanoSaudeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PacientePlanoSaudeController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/PacientePlanoSaude
        [HttpPost]
        public async Task<ActionResult> AssociatePacientePlanoSaude([FromQuery] int pacienteId, [FromQuery] int planoSaudeId)
        {
            if (!_context.Pacientes.Any(p => p.Id == pacienteId) || !_context.PlanosSaude.Any(p => p.Id == planoSaudeId))
            {
                return NotFound("Paciente ou Plano de Saúde não encontrado.");
            }

            var association = new PacientePlanoSaude { PacienteId = pacienteId, PlanoSaudeId = planoSaudeId };
            _context.PacientesPlanosSaude.Add(association);
            await _context.SaveChangesAsync();

            return Ok("Paciente associado ao Plano de Saúde com sucesso.");
        }

        // DELETE: api/PacientePlanoSaude
        [HttpDelete]
        public async Task<ActionResult> RemoveAssociation([FromQuery] int pacienteId, [FromQuery] int planoSaudeId)
        {
            var association = await _context.PacientesPlanosSaude
                .FirstOrDefaultAsync(ps => ps.PacienteId == pacienteId && ps.PlanoSaudeId == planoSaudeId);

            if (association == null)
            {
                return NotFound("Associação não encontrada.");
            }

            _context.PacientesPlanosSaude.Remove(association);
            await _context.SaveChangesAsync();

            return Ok("Associação entre Paciente e Plano de Saúde removida com sucesso.");
        }

        [HttpGet]
        public async Task<IActionResult> ListarPacientesAssociadosAsync([FromQuery] int planoSaudeId)
        {
            var pacientes = await _context.PacientesPlanosSaude
                .Where(pp => pp.PlanoSaudeId == planoSaudeId)
                .Select(pp => pp.Paciente)
                .ToListAsync();

            if (pacientes == null || !pacientes.Any())
            {
                return NotFound("Plano de Saúde não possui pacientes associados.");
            }

            return Ok(pacientes);
        }
    }
}
