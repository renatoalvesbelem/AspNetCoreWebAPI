using System;
using System.Collections.Generic;

namespace Smartschool.WebApi.Models
{
    public class Aluno
    {
        public Aluno()
        {

        }
        public Aluno(int id, int Matricula, string nome, string sobrenome, string telefone, DateTime DataNascimento)
        {
            this.Id = id;
            this.Nome = nome;
            this.SobreNome = sobrenome;
            this.Telefone = telefone;
            this.Matricula = Matricula;
            this.DataNascimento = DataNascimento;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Telefone { get; set; }
        public int Matricula { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public bool Ativo { get; set; } = true;
        public IEnumerable<AlunoDisciplina> AlunosDisciplinas { get; set; }
    }
}