using System.Collections.Generic;

namespace SmartSchool.WebAPI.V1.Dtos
{
    public class CursoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IEnumerable<DisciplinaDto> Disciplinas { get; set; }
    }
}