using Microsoft.EntityFrameworkCore;
using SCA_Console.Models;

namespace SCA_Console.Data.Configs
{
    public class ProfessoresConfiguration : IEntityTypeConfiguration<Professor>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Professor> builder)
        {
            builder.ToTable("Professores");
            builder.HasKey(p => p.idProfessor);
            builder.Property(p => p.nome).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Excluido).IsRequired();

            //builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
            //builder.Property(c => c.PricePerNight).HasColumnType("decimal(18,2)").IsRequired();
            //builder.Property(c => c.CityId);


            ///////////////////////////////////////////////////// [ᓚᘏᗢ] Mocks

            //builder.HasData(
            //    new Professor { idProfessor = 1, nome = "propriedade", ativo = true, Excluido = false },
            //    new Professor { idProfessor = 2, nome = "propriedade", ativo = false, Excluido = false }
            //    );
        }
    }
}
