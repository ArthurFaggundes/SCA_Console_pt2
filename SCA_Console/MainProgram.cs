using SCA_Console.Data;
using SCA_Console.Repository;
using SCA_Console.Services;
using SCA_Console.UI;

namespace SCA_Console
{
    internal class MainProgram
    {
        static void Main(string[] args)
        {
            var (alunoUI, disciplinaUI, professorUI, turmaUI) = InjetarDependencias();

            ConsoleInterface ConI = new();

            ConI.ConsoleHandler(alunoUI, disciplinaUI, professorUI, turmaUI);
        }

        public static (AlunoUI, DisciplinaUI, ProfessorUI, TurmaUI) InjetarDependencias()
        {
            ScaDBContext scaDBContext = new();

            // Camada que se comunica com o banco
            AlunoRepository alunoRepository = new(scaDBContext);
            DisciplinaRepository disciplinaRepository = new(scaDBContext);
            ProfessorRepository professorRepository = new(scaDBContext);
            TurmaRepository turmaRepository = new(scaDBContext);

            // Camada que trata erros
            AlunoService alunoService = new(alunoRepository);
            DisciplinaService disciplinaService = new(disciplinaRepository);
            ProfessorService professorService = new(professorRepository);
            TurmaService turmaService = new(turmaRepository, alunoRepository, professorRepository, disciplinaRepository);

            // Camada que apresenta as informações
            AlunoUI alunoUI = new(alunoService);
            DisciplinaUI disciplinaUI = new(disciplinaService);
            ProfessorUI professorUI = new(professorService);
            TurmaUI turmaUI = new(turmaService);

            return (alunoUI, disciplinaUI, professorUI, turmaUI);
        }
    }
}
