using Microsoft.EntityFrameworkCore;
using SCA_Console.Models;

namespace SCA_Console.Data.Configs
{
    public class AlunoConfiguration : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("Alunos");

            /////////////////////////////////////////////////////

            //builder.HasKey(a => a.id);
            //builder.Property(c => c.id);
            //builder.Property(c => c.nome).IsRequired().HasMaxLength(50);
            //builder.Property(c => c.CountryId);

            //builder.HasOne(c => c.Country) // Uma cídade tem um país
            //       .WithMany(co => co.Cities) // esse país tem várias cidades
            //       .HasForeignKey(c => c.CountryId) // eles se comunicam com o Country Id
            //       .OnDelete(DeleteBehavior.Cascade);

            ///////////////////////////////////////////////////// [ᓚᘏᗢ] Mocks

            //builder.HasData(
            //    new Aluno { id = 1, nome = "John Doe" },
            //    new Aluno { id = 2, nome = "Jane Smith" }
            //    );
        }
    }
}
