using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Smartschool.WebApi.Data;
using Smartschool.WebApi.Models;

namespace Smartschool.WebApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
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

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var professor = _context.Professores.FirstOrDefault(a => a.Id == id);
            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _context.Professores.Add(professor);
            _context.SaveChanges();
            return Ok(_context.Professores);
        }

        [HttpDelete("{id}")]
        public IActionResult Delele(int id)
        {
            var professor = _context.Professores.FirstOrDefault(a => a.Id == id);
            if (professor == null)
            {
                return BadRequest("Não foi possível encontrar o usuário");
            }
            _context.Professores.Remove(professor);
            _context.SaveChanges();
            return Ok(_context.Professores);
        }

        [HttpPut]
        public IActionResult Update(Professor professor)
        {
            _context.Professores.Update(professor);
            return Ok(_context.Professores);
        }

    }
}