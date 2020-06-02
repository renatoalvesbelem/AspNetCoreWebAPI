using System.Linq;
using Microsoft.EntityFrameworkCore;
using Smartschool.WebApi.Models;

namespace Smartschool.WebApi.Data
{
    public class Respository : IRepository
    {
        private readonly SmartContext _context;
        public Respository(SmartContext context)
        {
            _context = context;
        }

        public object IQueriable { get; private set; }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public Aluno[] GetAllAlunos(bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;
            if (includeProfessor)
            {
                query = query.Include(aluno => aluno.AlunosDisciplinas)
                .ThenInclude(ad => ad.Disciplina)
                .ThenInclude(d => d.Professor);
            }
            query = query.AsNoTracking()
            .OrderBy(aluno => aluno.Id);
            return query.ToArray();
        }

        public Aluno GetAlunoById(int alunoId, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;
            if (includeProfessor)
            {
                query = query.Include(aluno => aluno.AlunosDisciplinas)
                .ThenInclude(ad => ad.Disciplina)
                .ThenInclude(d => d.Professor);
            }
            query = query.AsNoTracking()
            .Where(aluno => aluno.Id == alunoId)
            .AsNoTracking()
            .OrderBy(aluno => alunoId);
            return query.FirstOrDefault();
        }

        public Aluno[] GetAllAlunosByDisciplinaId(int disciplinaId, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;
            if (includeProfessor)
            {
                query = query.Include(aluno => aluno.AlunosDisciplinas)
                .ThenInclude(ad => ad.Disciplina)
                .ThenInclude(d => d.Professor);
            }
            query = query.AsNoTracking()
            .Where(aluno => aluno.AlunosDisciplinas.Any(ad => ad.DisciplinaId == disciplinaId))
            .OrderBy(a => a.Id);
            return query.ToArray();
        }

        public Professor[] GetAllProfessores(bool includeAlunos = false)
        {
            IQueryable<Professor> query = _context.Professores;
            if (includeAlunos)
            {
                query = query.Include(professor => professor.Disciplinas)
                .ThenInclude(d => d.AlunoDisciplinas)
                .ThenInclude(ad => ad.Aluno);
            }
            query = query.AsNoTracking()
            .OrderBy(professor => professor.Id);
            return query.ToArray();
        }

        public Professor GetProfessoreById(int professorId, bool includeAlunos = false)
        {
            IQueryable<Professor> query = _context.Professores;
            if (includeAlunos)
            {
                query = query.Include(professor => professor.Disciplinas)
                .ThenInclude(d => d.AlunoDisciplinas)
                .ThenInclude(ad => ad.Aluno);
            }
            query = query.AsNoTracking()
            .Where(professor => professor.Id == professorId);
            return query.FirstOrDefault();
        }

        public Professor[] GetAllProfessoresByDisciplinaId(int disciplinaId, bool includeAlunos = false)
        {
            IQueryable<Professor> query = _context.Professores;
            if (includeAlunos)
            {
                query = query.Include(professor => professor.Disciplinas)
                .ThenInclude(d => d.AlunoDisciplinas)
                .ThenInclude(ad => ad.Aluno);
            }
            query = query.AsNoTracking()
            .Where(professor => professor.Disciplinas.Any(
                disciplina => disciplina.AlunoDisciplinas.Any(ad => ad.DisciplinaId == disciplinaId)))
            .OrderBy(professor => professor.Id);
            return query.ToArray();
        }

        public string pegaResposta()
        {
            return "Implementado";
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
    }
}