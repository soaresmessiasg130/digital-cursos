using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalCursos.Models.Models;

namespace DigitalCursos.Api.Repositories
{
  public interface IAlunoRepository
  {
    Task<IEnumerable<Aluno>> GetAlunos();
    Task<Aluno> CreateAluno(Aluno aluno);
    Task<Aluno> GetAluno(int id);
    Task<Aluno> UpdateAluno(Aluno aluno);
    Task<Aluno> DeleteAluno(int id);
  }
  public interface ICursoRepository
  {
    Task<IEnumerable<Curso>> GetCursos();
    Task<Curso> CreateCurso(Curso curso);
    Task<Curso> GetCurso(int id);
    Task<Curso> UpdateCurso(Curso curso);
    Task<Curso> DeleteCurso(int id);
  }
}
