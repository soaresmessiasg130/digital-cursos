using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalCursos.Models.Models;

namespace DigitalCursos.Web.Services
{
  public interface ICursoService
  {
    Task<IEnumerable<Curso>> GetCursos ();
    Task<Curso> GetCurso (int id);
    Task<Curso> CreateCurso (Curso curso);
    Task<Curso> UpdateCurso (Curso curso);
    Task DeleteCurso (int id);
  }
}
