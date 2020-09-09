using System.Threading.Tasks;
using DigitalCursos.Api.Repositories;
using DigitalCursos.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalCursos.Api.Controller
{
  [ApiController]
  [Route("api/[controller]")]
  public class CursoController : ControllerBase
  {
    private readonly ICursoRepository _repo;

    public CursoController(ICursoRepository repo)
    {
      _repo = repo;
    }

    [HttpGet]
    public async Task<ActionResult> GetCursos()
    {
      try
      {
        var result = await _repo.GetCursos();

        return Ok(result);
      }
      catch (System.Exception)
      {
        return StatusCode(
          StatusCodes.Status500InternalServerError,
          "Erro no retorno da lista de cursos."
        );
      }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Curso>> GetCurso(int id)
    {
      try
      {
        var res = await _repo.GetCurso(id);

        if (res == null) {
          return NotFound(
            $"Curso com id = {id} não encontrado!"
          );
        }

        return res;
      }
      catch (System.Exception)
      {
        return StatusCode(
          StatusCodes.Status500InternalServerError,
          "Erro no retorno do curso solicitado."
        );
      }
    }

    [HttpPost]
    public async Task<IActionResult> CreateCurso([FromBody] Curso curso)
    {
      try
      {
        if (curso == null) {
          return BadRequest();
        }

        var createdCurso = await _repo.CreateCurso(curso);

        return CreatedAtAction(
          nameof(GetCurso),
          new { id = createdCurso.CursoId },
          createdCurso
        );
      }
      catch (System.Exception)
      {
        return StatusCode(
          StatusCodes.Status500InternalServerError,
          "Erro na criação do curso desejado!"
        );
      }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<Curso>> UpdateCurso(int id, [FromBody] Curso curso)
    {
      try
      {
        if (id != curso.CursoId) {
          return BadRequest(
            $"Curso com id = {id} não confere com o Curso a ser atualizado"
          );
        }

        var cursoToUpdate = await _repo.GetCurso(id);

        if (cursoToUpdate == null) {
          return NotFound(
            $"Curso com id = {id} não encontrado!"
          );
        }

        return await _repo.UpdateCurso(curso);
      }
      catch (System.Exception)
      {
        return StatusCode(
          StatusCodes.Status500InternalServerError,
          "Update do Curso desejado não realizado!"
        );
      }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Curso>> DeleteCurso(int id)
    {
      try
      {
        var cursoToDelete = await _repo.GetCurso(id);

        if (cursoToDelete == null) {
          return BadRequest(
            $"Curso com id = {id} não encontrado!"
          );
        }
        return await _repo.DeleteCurso(id);
      }
      catch (System.Exception)
      {
        return StatusCode(
          StatusCodes.Status500InternalServerError
        );
      }
    }

  }
}
