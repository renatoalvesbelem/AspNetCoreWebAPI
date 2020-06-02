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
        private readonly IRepository _repo;

        public ProfessorController(SmartContext context, IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetAllProfessores(true));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_repo.GetProfessoreById(id, true));
        }


        [HttpGet("byDisciplina")]

        public IActionResult GetByDisciplinaId(int disciplinaId)
        {
            return Ok(_repo.GetAllProfessoresByDisciplinaId(disciplinaId, true));
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repo.Add(professor);
            _repo.SaveChanges();
            return Ok(_repo.GetAllProfessores());
        }

        [HttpDelete("{id}")]
        public IActionResult Delele(int id)
        {
            var professor = _repo.GetProfessoreById(id);
            if (professor == null)
            {
                return BadRequest("Não foi possível encontrar o usuário");
            }
            _repo.Delete(professor);
            _repo.SaveChanges();
            return Ok(_repo.GetAllProfessores());
        }

        [HttpPut]
        public IActionResult Update(Professor professor)
        {
            _repo.Update(professor);
            return Ok(_repo.GetAllProfessores());
        }

    }
}