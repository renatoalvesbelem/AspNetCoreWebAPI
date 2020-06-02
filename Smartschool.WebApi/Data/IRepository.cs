using Smartschool.WebApi.Models;

namespace Smartschool.WebApi.Data
{
    public interface IRepository
    {
        string pegaResposta();
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        Aluno[] GetAllAlunos(bool includeProfessor = false);
        Aluno GetAlunoById(int idAluno, bool includeProfessor = false);
        Aluno[] GetAllAlunosByDisciplinaId(int disciplinaId, bool includeProfessor = false);

        Professor[] GetAllProfessores(bool includeAlunos = false);
        Professor GetProfessoreById(int professorId, bool includeAlunos = false);
        Professor[] GetAllProfessoresByDisciplinaId(int disciplinaId, bool includeAlunos = false);
    }
}