using Microsoft.EntityFrameworkCore;
using SCA_Console.Models;

namespace SCA_Console.Data
{
    public class ScaDBContext : DbContext
    {
        //public ScaDBContext() { }
        //public ScaDBContext(DbContextOptions<ScaDBContext> options) : base(options) { }

        /////////////////////////////////////////////////////

        public virtual DbSet<Aluno> Alunos { get; set; }
        public virtual DbSet<Disciplina> Disciplinas { get; set; }
        public virtual DbSet<Professor> Professores { get; set; }
        public virtual DbSet<Turma> Turmas { get; set; }

        /////////////////////////////////////////////////////

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.ApplyConfigurationsFromAssembly(typeof(ScaDBContext).Assembly);
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=sca_infnet;Trusted_Connection=True;MultipleActiveResultSets=true"
                //sqlOptions => sqlOptions.EnableRetryOnFailure()
            );
        }
    }
}
