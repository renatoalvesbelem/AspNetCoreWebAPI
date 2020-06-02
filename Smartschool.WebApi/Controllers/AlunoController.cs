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
        private readonly IRepository _repo;
        public AlunoController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("pegaResposta")]
        public IActionResult pegaResposta()
        {
            return Ok(_repo.pegaResposta());
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetAllAlunos(true));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var aluno = _repo.GetAlunoById(id, true);

            return Ok(aluno);
        }

        [HttpGet("byDisciplina")]
        public IActionResult GetByDisciplina(int disciplinaId)
        {
            var aluno = _repo.GetAllAlunosByDisciplinaId(disciplinaId, false);
            return Ok(aluno);
        }


        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _repo.Add(aluno);
            _repo.SaveChanges();
            return Ok(_repo.GetAllAlunos());
        }

        [HttpDelete("{id}")]
        public IActionResult Delele(int id)
        {
            var aluno = _repo.GetAlunoById(id);
            if (aluno == null)
            {
                return BadRequest("Não foi possível encontrar o usuário");
            }
            _repo.Delete(aluno);
            _repo.SaveChanges();
            return Ok(_repo.GetAllAlunos());
        }

        [HttpPut]
        public IActionResult Update(Aluno aluno)
        {
            _repo.Update(aluno);
            return Ok(_repo.GetAllAlunos());
        }
    }
}