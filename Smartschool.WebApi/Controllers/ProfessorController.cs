using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Smartschool.WebApi.Data;
using Smartschool.WebApi.Dtos;
using Smartschool.WebApi.Models;

namespace Smartschool.WebApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;
        public ProfessorController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("getRegister")]
        public IActionResult GetRegister()
        {
            return Ok(new ProfessorRegistroDto());
        }

        [HttpGet]
        public IActionResult Get()
        {
            var professores = _repo.GetAllProfessores(true);
            var professorDto = _mapper.Map<IEnumerable<ProfessorDto>>(professores);
            return Ok(professorDto);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var professor = _repo.GetProfessoreById(id, true);
            var professorDto = _mapper.Map<ProfessorDto>(professor);
            return Ok(professorDto);
        }


        [HttpGet("byDisciplina")]
        public IActionResult GetByDisciplinaId(int disciplinaId)
        {
            var professores = _repo.GetAllProfessoresByDisciplinaId(disciplinaId, true);
            var professoresDto = _mapper.Map<IEnumerable<ProfessorDto>>(professores);
            return Ok(professoresDto);
        }

        [HttpPost]
        public IActionResult Post(ProfessorRegistroDto model)
        {
            var professor = _mapper.Map<Professor>(model);
            _repo.Add(professor);
            if (_repo.SaveChanges())
            {
                return Created($"api/professor/{professor.Id}", _mapper.Map<ProfessorDto>(professor));
            }
            return BadRequest("Não foi possível cadastrar o professor");
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
            var professores = _repo.GetAllProfessores();
            return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(professores));
        }

        [HttpPut]
        public IActionResult Update(ProfessorRegistroDto model)
        {
            var professor = _mapper.Map<Professor>(model);
            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Created($"api/professor/{professor.Id}", _mapper.Map<ProfessorDto>(professor));
            }
            return BadRequest("Não foi possível atualizar o professor");
        }

    }
}