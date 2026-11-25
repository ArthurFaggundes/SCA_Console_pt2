using SCA_Console.Models;
using SCA_Console.Services;

namespace SCA_Console.UI
{
    public class ProfessorUI
    {
        private ProfessorService _professorService;
        public ProfessorUI(ProfessorService professorService)
        { _professorService = professorService; }


        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public void CriarNovoProfessor()
        {
            Console.WriteLine("\n--- Criar novo professor ---");
            try
            {
                Console.Write("Insira o ID do professor: ");
                int id = utilFuncs.EntrarId();
                Console.Write("Insira o nome do professor: ");
                string nome = utilFuncs.EntrarNome();

                Professor tempProfessor = new Professor(id, nome);
                _professorService.CriarProfessor(tempProfessor);

                Console.WriteLine("\n[Sucesso] Professor cadastrado!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////
        public void ExcluirProfessor()
        {
            Console.WriteLine("\n--- Excluir professor ---");
            try
            {
                Console.Write("Insira o ID do professor: ");
                int id = utilFuncs.EntrarId();

                _professorService.ExcluirProfessor(id);

                Console.WriteLine($"\n[Sucesso] Professor {id} excluído!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////
        public void MostrarTodosOsProfessores()
        {
            Console.WriteLine("\n--- Lista de professores ---");

            List<Professor> professores = _professorService.ListarProfessores();

            foreach (Professor p in professores)
            {
                Console.WriteLine($"- {p}");
            }
            Console.WriteLine("___________________________");
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////
        public void MostrarTurmasDoProfessor()
        {
            Console.WriteLine("\n--- Buscar turmas do professor ---");
            try
            {
                Console.Write("Insira o ID do professor: ");
                int id = utilFuncs.EntrarId();

                List<Turma> turmas = _professorService.MostrarTurmasDoProfessor(id);

                Console.WriteLine($"Turmas designadas ({turmas.Count}):");
                foreach (Turma t in turmas)
                {
                    Console.WriteLine($"- {t}");
                }
                Console.WriteLine("___________________________");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}