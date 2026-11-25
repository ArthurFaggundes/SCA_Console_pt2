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
            Console.WriteLine("\n--- Criar nova disciplina ---");
            try
            {
                Console.Write("Insira o ID da disciplina: ");
                int id = utilFuncs.EntrarId();
                Console.Write("Insira o nome da disciplina: ");
                string nome = utilFuncs.EntrarNome();

                Disciplina tempDisciplina = new Disciplina(id, nome);
                _disciplinaService.CriarDisciplina(tempDisciplina);

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
            Console.WriteLine("\n--- Excluir disciplina ---");
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
            Console.WriteLine("\n--- Lista de disciplinas ---");

            List<Disciplina> disciplinas = _disciplinaService.ListarDisciplinas();

            foreach (Disciplina d in disciplinas)
            {
                Console.WriteLine($"- {d}");
            }
            Console.WriteLine("___________________________");
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////
        public void MostrarTurmasDaDisciplina()
        {
            Console.WriteLine("\n--- Buscar turmas da disciplina ---");
            try
            {
                Console.Write("Insira o ID da disciplina: ");
                int id = utilFuncs.EntrarId();
                List<Turma> turmas = _disciplinaService.MostrarTurmasDaDisciplina(id);

                Console.WriteLine($"Turmas atribuidas ({turmas.Count}):");
                foreach (Turma t in turmas)
                {
                    Console.WriteLine($"- {t.idTurma}\n - {t.local}\n - {t.professor}\n - {t.Excluida}\n");
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