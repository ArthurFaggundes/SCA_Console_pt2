using SCA_Console.Models;
using SCA_Console.Services;

namespace SCA_Console.UI
{
    public class AlunoUI
    {
        private AlunoService _alunoService;
        public AlunoUI(AlunoService alunoService)
            { _alunoService = alunoService; }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public void CriarNovoAluno()
        {
            Console.WriteLine("\n--- Criar novo aluno ---\n");
            try
            {
                Console.Write("Insira o nome do aluno: ");
                string nome = utilFuncs.EntrarNome();

                _alunoService.CriarAluno(new Aluno(nome));

                Console.WriteLine("\n[Sucesso] Aluno cadastrado!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////
        public void ExcluirAluno()
        {
            Console.WriteLine("\n--- Excluir aluno ---\n");
            try
            {
                Console.Write("Insira o ID do aluno: ");
                int id = utilFuncs.EntrarId();

                _alunoService.ExcluirAluno(id);

                Console.WriteLine($"\n[Sucesso] Aluno {id} excluído!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public void MostrarCreditosAtuais()
        {
            Console.WriteLine("\n--- Mostrar créditos atuais do aluno ---\n");
            try
            {
                Console.Write("Insira o ID do aluno: ");
                int id = utilFuncs.EntrarId();
                int creditos = _alunoService.MostrarCreditosAtuais(id);

                Console.WriteLine($"\nCréditos atuais do aluno: {creditos}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////
        public void MostrarTodosOsAlunos()
        {
            Console.WriteLine("\n--- Lista de alunos ---\n");

            List<Aluno> alunos = _alunoService.ListarAlunos();

            foreach (Aluno a in alunos)
            {
                Console.WriteLine($"- {a}");
            }
            Console.WriteLine("_______________________");
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////
        public void MostrarTurmasDoAluno()
        {
            Console.WriteLine("\n--- Buscar turmas do aluno ---\n");
            try
            {
                Console.Write("Insira o ID do aluno: ");
                int id = utilFuncs.EntrarId();
                List<Turma> turmas = _alunoService.MostrarTurmasDoAluno(id);

                Console.WriteLine($"Turmas inscritas ({turmas.Count}):\n");

                foreach (Turma t in turmas)
                {
                    Console.WriteLine($"{t}");
                }
                Console.WriteLine("______________________________");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}