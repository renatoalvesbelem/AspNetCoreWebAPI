using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Smartschool.WebApi.Data;
using Smartschool.WebApi.Dtos;
using Smartschool.WebApi.Models;

namespace Smartschool.WebApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repo;
        private IMapper _mapper;
        public AlunoController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("pegaResposta")]
        public IActionResult pegaResposta()
        {
            return Ok(_repo.pegaResposta());
        }

        [HttpGet("getRegister")]
        public IActionResult GetRegister()
        {
            return Ok(new AlunoRegistrarDto());
        }

        [HttpGet]
        public IActionResult Get()
        {
            var alunos = _repo.GetAllAlunos(true);
            return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var aluno = _repo.GetAlunoById(id, true);
            var alunoDto = _mapper.Map<AlunoDto>(aluno);
            return Ok(alunoDto);
        }

        [HttpGet("byDisciplina")]
        public IActionResult GetByDisciplina(int disciplinaId)
        {
            var aluno = _repo.GetAllAlunosByDisciplinaId(disciplinaId, false);
            return Ok(_mapper.Map<AlunoDto>(aluno));
        }

        [HttpPost]
        public IActionResult Post(AlunoRegistrarDto model)
        {
            var aluno = _mapper.Map<Aluno>(model);
            _repo.Add(aluno);
            if (_repo.SaveChanges())
            {
                return Created($"/api/aluno/{aluno.Id}", _mapper.Map<AlunoDto>(aluno));
            }

            return BadRequest("Aluno não foi cadastrado");
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
            var alunos = _repo.GetAllAlunos();
            return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));
        }

        [HttpPut]
        public IActionResult Update(AlunoRegistrarDto model)
        {
            var aluno = _mapper.Map<Aluno>(model);
            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Created($"/api/aluno/{aluno.Id}", _mapper.Map<AlunoDto>(aluno));
            }
            return BadRequest("Aluno não foi cadastrado");
        }
    }
}