using SCA_Console.Models;
using SCA_Console.Services;

namespace SCA_Console.UI
{
    public class DisciplinaUI
    {
        private DisciplinaService _disciplinaService;
        public DisciplinaUI(DisciplinaService disciplinaService)
            { _disciplinaService = disciplinaService; }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public void CriarNovaDisciplina()
        {
            Console.WriteLine("\n--- Criar nova disciplina ---\n");
            try
            {
                Console.Write("Insira o nome da disciplina: ");
                string nome = utilFuncs.EntrarNome();

                _disciplinaService.CriarDisciplina(new Disciplina(nome));

                Console.WriteLine("\n[Sucesso] Disciplina cadastrada!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////
        public void ExcluirDisciplina()
        {
            Console.WriteLine("\n--- Excluir disciplina ---\n");
            try
            {
                Console.Write("Insira o ID da disciplina: ");
                int id = utilFuncs.EntrarId();

                _disciplinaService.ExcluirDisciplina(id);

                Console.WriteLine($"\n[Sucesso] Disciplina {id} excluída!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public void MostrarTodasAsDisciplinas()
        {
            Console.WriteLine("\n--- Lista de disciplinas ---\n");

            List<Disciplina> disciplinas = _disciplinaService.ListarDisciplinas();

            foreach (Disciplina d in disciplinas)
            {
                Console.WriteLine($"- {d}");
            }
            Console.WriteLine("____________________________");
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////
        public void MostrarTurmasDaDisciplina()
        {
            Console.WriteLine("\n--- Buscar turmas da disciplina ---\n");
            try
            {
                Console.Write("Insira o ID da disciplina: ");
                int id = utilFuncs.EntrarId();
                List<Turma> turmas = _disciplinaService.MostrarTurmasDaDisciplina(id);

                Console.WriteLine($"Turmas atribuidas ({turmas.Count}):\n");
                foreach (Turma t in turmas)
                {
                    Console.WriteLine($"- {t}");
                }
                Console.WriteLine("_____________________________________");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}