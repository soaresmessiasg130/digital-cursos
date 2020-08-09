using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalCursos.Api.Context;
using DigitalCursos.Models.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DigitalCursos.Api.Repositories
{
  public class AlunoRepository : IAlunoRepository
  {
    private readonly AppDbContext _context;

    public AlunoRepository(AppDbContext context)
    {
      _context = context;
    }

    public async Task<Aluno> CreateAluno(Aluno aluno)
    {
      var res = await _context.DCAluno.AddAsync(aluno);

      await _context.SaveChangesAsync();

      return res.Entity;
    }

    public async Task<Aluno> DeleteAluno(int id)
    {
      var aluno = _context.DCAluno.FirstOrDefault(aluno => aluno.AlunoId == id);

      if (aluno != null) {
        _context.DCAluno.Remove(aluno);

        var res = await _context.SaveChangesAsync();

        return aluno;
      }

      return null;
    }

    public async Task<Aluno> GetAluno(int id)
    {
      return await
        _context.DCAluno.FirstOrDefaultAsync(
          aluno => aluno.AlunoId == id
        );
    }

    public async Task<IEnumerable<Aluno>> GetAlunos()
    {
      return await
        _context.DCAluno.AsNoTracking().ToListAsync();
    }

    public async Task<Aluno> UpdateAluno(Aluno aluno)
    {
      var res = _context.DCAluno.FirstOrDefault(
        aluno => aluno.AlunoId == aluno.AlunoId
      );

      if (res != null) {
        res.Nome = aluno.Nome;
        res.Sobrenome = aluno.Sobrenome;
        res.Email = aluno.Email;
        res.Nascimento = aluno.Nascimento;
        res.Foto = aluno.Foto;
        res.Genero = aluno.Genero;
        res.CursoId = aluno.CursoId;

        await _context.SaveChangesAsync();

        return res;
      }

      return null;
    }
  }
}
