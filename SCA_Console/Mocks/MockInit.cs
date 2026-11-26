using SCA_Console.Data;
using SCA_Console.Mocks;

namespace SCA_Console
{
    public static class MockInit
    {
        public static void CriarMocks(ScaDBContext context)
        {
            //! SÓ FUNCIONA SE NÃO TIVER NADA NO BANCO
            if (context.Alunos.Any() || 
                context.Disciplinas.Any() || 
                context.Professores.Any() || 
                context.Turmas.Any()) 
            { return; }

            context.Alunos.AddRange(GeneralMocks.GerarAlunos());
            context.Disciplinas.AddRange(GeneralMocks.GerarDisciplinas());
            context.Professores.AddRange(GeneralMocks.GerarProfessores());
            context.Turmas.AddRange(GeneralMocks.GerarTurmas());

            context.SaveChanges();
        }
    }
}