using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalCursos.Api.Context;
using DigitalCursos.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalCursos.Api.Repositories
{
  public class CursoRepository : ICursoRepository
  {
    private readonly AppDbContext _context;

    public CursoRepository(AppDbContext context)
    {
      _context = context;
    }

    public async Task<Curso> CreateCurso(Curso curso)
    {
      var res = await _context.DCCurso.AddAsync(curso);

      await _context.SaveChangesAsync();

      return res.Entity;
    }

    public async Task<Curso> DeleteCurso(int id)
    {
      var curso = _context.DCCurso.FirstOrDefault(
        a => a.CursoId == id
      );

      if (curso != null) {
        _context.DCCurso.Remove(curso);

        var res = await _context.SaveChangesAsync();

        return curso;
      }

      return null;
    }

    public async Task<Curso> GetCurso(int id)
    {
      return await _context.DCCurso.FirstOrDefaultAsync(
        c => c.CursoId == id
      );
    }

    public async Task<IEnumerable<Curso>> GetCursos()
    {
      return await _context.DCCurso.AsNoTracking().ToListAsync();
    }

    public async Task<Curso> UpdateCurso(Curso curso)
    {
      var res = await _context.DCCurso.FirstOrDefaultAsync(
        c => c.CursoId == curso.CursoId
      );

      if (res != null) {
        res.CursoNome = curso.CursoNome;
        res.Descricao = curso.Descricao;
        res.CargaHoraria = curso.CargaHoraria;
        res.Inicio = curso.Inicio;
        res.Logo = curso.Logo;
        res.Preco = curso.Preco;

        await _context.SaveChangesAsync();

        return res;
      }

      return null;
    }
  }
}
