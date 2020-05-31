using System;

namespace SmartSchool.WebAPI.V2.Dtos
{
    public class AlunoDto
    {
        /// <summary>
        /// Identificador e chave do Banco
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Chave do Aluno, para outros neg�cios na Institui��o
        /// </summary>
        public int Matricula { get; set; }     
        /// <summary>
        /// Nome � o Primeiro nome o o Sobrenome do Aluno
        /// </summary>
        public string Nome { get; set; }
        public string Telefone { get; set; }
        /// <summary>
        /// Esta idade � o calculo relacionado a data de nascimento do Aluno
        /// </summary>
        public int Idade { get; set; }
        public DateTime DataIni { get; set; }
        /// <summary>
        /// Ativar ou n�o o Aluno
        /// </summary>
        public bool Ativo { get; set; }
    }
}