using System;
using System.Collections.Generic;

namespace Smartschool.WebApi.Models
{
    public class Professor
    {
        public Professor()
        {

        }
        public Professor(int id, int Registro, string nome, string Sobrenome)
        {
            this.Id = id;
            this.Nome = nome;
            this.Sobrenome = Sobrenome;
            this.Registro = Registro;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public int Registro { get; set; }
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public bool Ativo { get; set; } = true;
        public IEnumerable<Disciplina> Disciplinas { get; set; }
    }
}