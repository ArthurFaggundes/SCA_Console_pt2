using Microsoft.EntityFrameworkCore;
using SCA_Console.Models;

namespace SCA_Console.Data.Configs
{
    internal class TurmaConfiguration : IEntityTypeConfiguration<Turma>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Turma> builder)
        {
            //builder.ToTable("Turmas");
            //builder.HasKey(t => t.idTurma);
            //builder.Property(t => t.local).IsRequired().HasMaxLength(100);
            //builder.Property(t => t.aberta).IsRequired();
            //builder.Property(t => t.Excluida).IsRequired();

            //builder.HasMany(t => t.alunos)
            //   .WithMany(a => a.turmas)
            //   .HasForeignKey(a => a.idTurma)
            //   .OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne(t => t.professor)
            //   .WithMany(p => p.turmas)
            //   .HasForeignKey(t => t.idProfessor)
            //   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
