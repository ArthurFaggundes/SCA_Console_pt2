using Microsoft.EntityFrameworkCore;
using SCA_Console.Models;

namespace SCA_Console.Data
{
    public class ScaContext : DbContext
    {
        public ScaContext() { }
        public ScaContext(DbContextOptions<ScaContext> options) : base(options) { }

        /////////////////////////////////////////////////////

        public virtual DbSet<Aluno> Alunos { get; set; }
        public virtual DbSet<Disciplina> Disciplinas { get; set; }
        public virtual DbSet<Professor> Professores { get; set; }
        public virtual DbSet<Turma> Turmas { get; set; }

        /////////////////////////////////////////////////////

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ScaContext).Assembly);
        }
    }
}
