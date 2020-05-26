using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Smartschool.WebApi.Data;
using Smartschool.WebApi.Models;

namespace Smartschool.WebApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly SmartContext _context;

        public AlunoController(SmartContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            _context.SaveChanges();
            return Ok(_context.Alunos);
        }

        [HttpDelete("{id}")]
        public IActionResult Delele(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null)
            {
                return BadRequest("Não foi possível encontrar o usuário");
            }
            _context.Alunos.Remove(aluno);
            _context.SaveChanges();
            return Ok(_context.Alunos);
        }

        [HttpPut]
        public IActionResult Update(Aluno aluno)
        {
            _context.Alunos.Update(aluno);
            return Ok(_context.Alunos);
        }

    }
}