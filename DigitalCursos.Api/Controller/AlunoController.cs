using System.Threading.Tasks;
using DigitalCursos.Api.Repositories;
using DigitalCursos.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalCursos.Api.Controller
{
  [ApiController]
  [Route("api/[controller]")]
  public class AlunoController : ControllerBase
  {
    private readonly IAlunoRepository _repo;

    public AlunoController(IAlunoRepository repo)
    {
      _repo = repo;
    }

    [HttpGet]
    public async Task<ActionResult> GetAlunos()
    {
      try
      {
        var result = await _repo.GetAlunos();

        return Ok(result);
      }
      catch (System.Exception)
      {
        return StatusCode(
          StatusCodes.Status500InternalServerError,
          "Erro no retorno da lista de alunos."
        );
      }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Aluno>> GetAluno(int id)
    {
      try
      {
        var result = await _repo.GetAluno(id);

        if (result == null) {
          return NotFound($"O aluno com id = {id} não foi encontrado!");
        }

        return result;
      }
      catch (System.Exception)
      {
        return StatusCode(
          StatusCodes.Status500InternalServerError,
          "Erro no retorno da lista de alunos."
        );
      }
    }

    [HttpPost]
    public async Task<ActionResult> CreateAluno([FromBody] Aluno aluno)
    {
      try
      {
        if (aluno == null) {
          return BadRequest();
        }

        var createdAluno = await _repo.CreateAluno(aluno);

        return CreatedAtAction(
          nameof(GetAluno),
          new { id = createdAluno.CursoId },
          createdAluno
        );
      }
      catch (System.Exception)
      {
        return StatusCode(
          StatusCodes.Status500InternalServerError,
          "Erro no retorno da lista de alunos."
        );
      }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Aluno>> UpdateAluno(int id, Aluno aluno)
    {
      try
      {
        if (id != aluno.AlunoId) {
          return BadRequest(
            $"O Aluno com id = {id} não confere com o aluno a ser atualizado!"
          );
        }

        var alunoToUpdate = await _repo.GetAluno(id);

        if (alunoToUpdate == null) {
          return NotFound(
            $"Aluno com id = {id} não encontrado!"
          );
        }

        return await _repo.UpdateAluno(aluno);
      }
      catch (System.Exception)
      {
        return StatusCode(
          StatusCodes.Status500InternalServerError,
          "Erro no retorno da lista de alunos."
        );
      }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Aluno>> DeleteAluno(int id)
    {
      try
      {
        var alunoToDelete = await _repo.GetAluno(id);

        if (alunoToDelete == null) {
          return NotFound(
            $"Aluno com id = {id} não encontrado!"
          );
        }

        return await _repo.DeleteAluno(id);
      }
      catch (System.Exception)
      {
        return StatusCode(
          StatusCodes.Status500InternalServerError,
          "Erro no retorno da lista de alunos."
        );
      }
    }
  }
}
