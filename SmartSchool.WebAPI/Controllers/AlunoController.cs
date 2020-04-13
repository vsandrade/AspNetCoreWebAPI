using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{    
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>() {
            new Aluno() {
                Id = 1,
                Nome = "Marcos",
                Sobrenome = "Almeida",
                Telefone = "465464644"
            },
            new Aluno() {
                Id = 2,
                Nome = "Marta",
                Sobrenome = "Kente",
                Telefone = "789789787"
            },
            new Aluno() {
                Id = 3,
                Nome = "Laura",
                Sobrenome = "Maria",
                Telefone = "456789456"
            },
        };

        public AlunoController() { }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        // api/aluno/byId
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("O Aluno não foi encontrado");

            return Ok(aluno);
        }

        // api/aluno/nome
        [HttpGet("ByName")]
        public IActionResult GetByName(string nome, string Sobrenome)
        {
            var aluno = Alunos.FirstOrDefault(a => 
                a.Nome.Contains(nome) && a.Sobrenome.Contains(Sobrenome)
            );
            if (aluno == null) return BadRequest("O Aluno não foi encontrado");

            return Ok(aluno);
        }

        // api/aluno
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        // api/aluno
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        // api/aluno
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}