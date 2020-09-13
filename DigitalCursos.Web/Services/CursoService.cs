using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using DigitalCursos.Models.Models;

namespace DigitalCursos.Web.Services
{
  public class CursoService : ICursoService
  {
    public HttpClient _http;
    public CursoService(HttpClient http)
    {
      _http = http;
    }
    public async Task<Curso> CreateCurso(Curso curso)
    {
      var response = await _http.PostAsJsonAsync<Curso>(
        $"api/curso",
        curso
      );

      var content = await response.Content.ReadFromJsonAsync<Curso>();

      return content;
    }

    public async Task DeleteCurso(int id)
    {
      await _http.DeleteAsync(
        $"api/curso/{id}"
      );
    }

    public async Task<Curso> GetCurso(int id)
    {
      var curso = await _http.GetFromJsonAsync<Curso>(
        $"api/curso/{id}"
      );

      return curso;
    }

    public async Task<IEnumerable<Curso>> GetCursos()
    {
      var cursos = await _http.GetFromJsonAsync<IEnumerable<Curso>>(
        $"api/curso"
      );

      return cursos;
    }

    public async Task<Curso> UpdateCurso(Curso curso)
    {
      var response = await _http.PutAsJsonAsync<Curso>(
        $"api/curso/{curso.CursoId}",
        curso
      );

      var content = await response.Content.ReadFromJsonAsync<Curso>();

      return content;
    }
  }
}
