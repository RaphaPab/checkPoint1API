﻿using checkPoint1.Data;
using checkPoint1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace checkPoint1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : Controller
    {
        private readonly AppDbContext _context;

        public PacienteController(AppDbContext context)
        {
            _context = context;
        }


        // GET: api/Pacientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paciente>>> GetPaciente()

        {
            return await _context.Pacientes.ToListAsync();
        }

        // GET: api/Pacientes/5
        [HttpGet("{id}")]
        public ActionResult<Paciente> GetPaciente(int id)
        {
            var paciente = _context.Pacientes.Find(id);

            if (paciente == null)
            {
                return NotFound();
            }

            return paciente;
        }





        // PUT: api/Paciente/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaciente(int id, Paciente paciente)
        {
            if (id != paciente.Id)
            {
                return BadRequest();
            }

            _context.Entry(paciente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacienteExists(id)) {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // POST: api/Pacientes
        [HttpPost]
        public async Task<ActionResult<Paciente>> PostPaciente(Paciente paciente)
        {
            
            _context.Pacientes.Add(paciente);

            
            await _context.SaveChangesAsync();

            
            return CreatedAtAction("GetPaciente", new { id = paciente.Id }, paciente);
        }




        // DELETE: api/Pacientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaciente(int id)
        {
            var paciente =await _context.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }


            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();
            return NoContent();
        
        }

        private bool PacienteExists(int id)
        {
            return _context.Pacientes.Any(e => e.Id == id);
        }

    }
}
