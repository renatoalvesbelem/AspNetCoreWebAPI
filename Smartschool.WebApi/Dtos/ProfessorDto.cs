using System;

namespace Smartschool.WebApi.Dtos
{
    public class ProfessorDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Registro { get; set; }
        public bool Ativo { get; set; }
    }
}