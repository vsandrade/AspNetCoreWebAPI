using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly SmartContext _context;

        public ProfessorController(SmartContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professores);
        }

        // api/Professor/byId
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var Professor = _context.Professores.FirstOrDefault(a => a.Id == id);
            if (Professor == null) return BadRequest("O Professor não foi encontrado");

            return Ok(Professor);
        }

        // api/Professor/nome
        [HttpGet("ByName")]
        public IActionResult GetByName(string nome)
        {
            var Professor = _context.Professores.FirstOrDefault(a => 
                a.Nome.Contains(nome)
            );
            if (Professor == null) return BadRequest("O Professor não foi encontrado");

            return Ok(Professor);
        }

        // api/Professor
        [HttpPost]
        public IActionResult Post(Professor Professor)
        {
            _context.Add(Professor);
            _context.SaveChanges();
            return Ok(Professor);
        }

        // api/Professor
        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor Professor)
        {
            var prof = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (prof == null) return BadRequest("Professor não encontrado");

            _context.Update(Professor);
            _context.SaveChanges();
            return Ok(Professor);
        }

        // api/Professor
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor Professor)
        {
            var alu = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alu == null) return BadRequest("Professor não encontrado");

            _context.Update(Professor);
            _context.SaveChanges();
            return Ok(Professor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Professor = _context.Professores.FirstOrDefault(a => a.Id == id);
            if (Professor == null) return BadRequest("Professor não encontrado");

             _context.Remove(Professor);
            _context.SaveChanges();
            return Ok();
        }
    }
}