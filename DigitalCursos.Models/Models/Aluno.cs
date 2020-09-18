using System;
using System.ComponentModel.DataAnnotations;

namespace DigitalCursos.Models.Models
{
  public class Aluno
  {
    public int AlunoId { get; set; }
    [Required(ErrorMessage = "Informe o nome do aluno.")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Informe o sobrenome do aluno.")]
    public string Sobrenome { get; set; }
    [Required(ErrorMessage = "Informe o email do aluno.")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Informe a data de nascimento do aluno.")]
    public DateTime Nascimento { get; set; }
    public byte[] Foto { get; set; }
    [Required(ErrorMessage = "Informe o sexo do aluno.")]
    public Genero Genero { get; set; }
    [Required(ErrorMessage = "Informe o Curso do aluno.")]
    public Curso Curso { get; set; }
    public int CursoId { get; set; }
  }
}
