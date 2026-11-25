using Microsoft.EntityFrameworkCore;
using SCA_Console.Models;

namespace SCA_Console.Data.Configs
{
    public class DisciplinaConfiguration : IEntityTypeConfiguration<Disciplina>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Disciplina> builder)
        {
            builder.ToTable("Disciplinas");
            builder.HasKey(c => c.idDisciplina);


            /////////////////////////////////////////////////////

            //builder.Property(c => c.Id);
            //builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
            //builder.Property(c => c.DisciplinaCode).IsRequired().HasMaxLength(5);

            ///////////////////////////////////////////////////// [ᓚᘏᗢ] Mocks

            //builder.HasData(
            //    new Disciplina { Id = 1, Name = "United States", DisciplinaCode = "US" },
            //    new Disciplina { Id = 2, Name = "Brazil", DisciplinaCode = "BR" }
            //    );
        }
    }
}
