using System.Collections.Generic;

namespace SmartSchool.WebAPI.Models
{
    public class Disciplina
    {
        public Disciplina() { }
        public Disciplina(int id, string nome, int professorId, int cursoId)
        {
            this.Id = id;
            this.Nome = nome;
            this.ProfessorId = professorId;
            this.CursoId = cursoId;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CargaHoraria { get; set; }
        public int? PrerequisitoId { get; set; } = null;
        public Disciplina Prerequisito { get; set; }
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }
        public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }
    }
}