using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using DigitalCursos.Models.Models;

namespace DigitalCursos.Web.Services
{
  public class AlunoService : IAlunoService
  {
    public HttpClient _httpClient;
    public AlunoService(HttpClient client)
    {
      _httpClient = client;
    }

    public async Task<Aluno> CreateAluno(Aluno aluno)
    {
      var response = await _httpClient.PostAsJsonAsync<Aluno>(
        $"api/aluno",
        aluno
      );

      var content = await response.Content.ReadFromJsonAsync<Aluno>();

      return content;
    }

    public async Task DeleteAluno(int id)
    {
      await _httpClient.DeleteAsync($"api/aluno/{id}");
    }

    public async Task<Aluno> GetAluno(int id)
    {
      var aluno = await _httpClient.GetFromJsonAsync<Aluno>($"api/aluno/{id}");

      return aluno;
    }

    public async Task<IEnumerable<Aluno>> GetAlunos()
    {
      var alunos = await _httpClient.GetFromJsonAsync<IEnumerable<Aluno>>("api/aluno");

      return alunos;
    }

    public async Task<Aluno> UpdateAluno(Aluno aluno)
    {
      var response = await _httpClient.PutAsJsonAsync<Aluno>(
        $"api/aluno/{aluno.AlunoId}",
        aluno
      );

      var content = await response.Content.ReadFromJsonAsync<Aluno>();

      return content;
    }
  }
}
