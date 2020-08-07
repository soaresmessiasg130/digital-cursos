using System;
using System.Collections.Generic;
using DigitalCursos.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace DigitalCursos.Api.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) {}

        public DbSet<Aluno> DCAluno { get; set; }
        public DbSet<Curso> DCCurso { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            modelBuilder.Entity<Curso>().HasKey(o => o.CursoId);

            modelBuilder.Entity<Curso>().Property(o => o.CursoNome).HasMaxLength(150);

            modelBuilder.Entity<Curso>().Property(o => o.Descricao).HasMaxLength(250);

            modelBuilder.Entity<Curso>().Property(o => o.Preco).HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Aluno>().Property(o => o.Nome).HasMaxLength(150);

            modelBuilder.Entity<Aluno>().Property(o => o.Sobrenome).HasMaxLength(100);

            modelBuilder.Entity<Aluno>().Property(o => o.Email).HasMaxLength(100);

            modelBuilder.Entity<Curso>().HasData(
                new List<Curso>{
                    new Curso {
                        CursoId = 1,
                        CursoNome = "ADS",
                        CargaHoraria = 40,
                        Inicio = new DateTime(2020,08,12),
                        Preco = 180.00M,
                        Logo = null
                    },
                    new Curso {
                        CursoId = 2,
                        CursoNome = "Redes",
                        CargaHoraria = 44,
                        Inicio = new DateTime(2020,08,13),
                        Preco = 200.00M,
                        Logo = null
                    },
                    new Curso {
                        CursoId = 3,
                        CursoNome = "Engenharia TI",
                        CargaHoraria = 60,
                        Inicio = new DateTime(2020,08,14),
                        Preco = 330.00M,
                        Logo = null
                    },
                }
            );

            modelBuilder.Entity<Aluno>().HasData(
                new List<Aluno>{
                    new Aluno {
                        AlunoId = 1,
                        Nome = "Messias Soares",
                        Sobrenome = "Paiva",
                        Email = "soaresmessiasg130@gmail.com",
                        Genero = Genero.Masculino,
                        Foto = null,
                        Nascimento = new DateTime(1997,08,12),
                        CursoId = 1,
                    },
                    new Aluno {
                        AlunoId = 2,
                        Nome = "Luana Gomes",
                        Sobrenome = "Soares",
                        Email = "luanagomessoares@gmail.com",
                        Genero = Genero.Feminino,
                        Foto = null,
                        Nascimento = new DateTime(1997,08,13),
                        CursoId = 2,
                    },
                    new Aluno {
                        AlunoId = 3,
                        Nome = "Fulano de Tal",
                        Sobrenome = "da Silva",
                        Email = "fulano@gmail.com",
                        Genero = Genero.Outro,
                        Foto = null,
                        Nascimento = new DateTime(1997,08,14),
                        CursoId = 3,
                    },
                }
            );
        }
    }
}