using System;

namespace SmartSchool.WebAPI.V2.Dtos
{
    /// <summary>
    /// Este � o DTO de Aluno para Registrar.
    /// </summary>
    public class AlunoRegistrarDto
    {
        /// <summary>
        /// Identificador e chave do Banco.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Chave do Aluno, para outros neg�cios na Institui��o.
        /// </summary>
        public int Matricula { get; set; }
        /// <summary>
        /// Nome � o Primeiro nome o o Sobrenome do Aluno.
        /// </summary>
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNasc { get; set; }
        public DateTime DataIni { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public bool Ativo { get; set; } = true;
    }
}