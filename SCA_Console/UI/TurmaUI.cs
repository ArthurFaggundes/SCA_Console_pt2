using SCA_Console.Models;
using SCA_Console.Services;

namespace SCA_Console.UI
{
    public class TurmaUI
    {
        private TurmaService _turmaService;
        public TurmaUI(TurmaService turmaService)
            { _turmaService = turmaService; }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public void CriarNovaTurma()
        {
            Console.WriteLine("\n--- Criar nova turma ---");
            try
            {
                Console.Write("Insira o ID da turma: ");
                int id = utilFuncs.EntrarId();

                Console.Write("Insira o nome do local: ");
                string local = utilFuncs.EntrarNome();

                Turma tempTurma = new Turma(id, local);
                _turmaService.CriarTurma(tempTurma);

                Console.WriteLine("\n[Sucesso] Turma cadastrada!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public void ExcluirTurma()
        {
            Console.WriteLine("\n--- Excluir turma ---");

            try
            {
                Console.Write("Insira o ID da turma: ");
                int id = utilFuncs.EntrarId();

                _turmaService.ExcluirTurma(id);

                Console.WriteLine($"\n[Sucesso] Turma {id} excluída!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////
        
        public void AbrirTurma()
        {
            Console.WriteLine("\n--- Abrir turma ---");

            try
            {
                Console.Write("Insira o ID da turma: ");
                int id = utilFuncs.EntrarId();

                _turmaService.AbrirTurma(id);

                Console.WriteLine("\n[Sucesso] Turma aberta!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public void FecharTurma()
        {
            Console.WriteLine("\n--- Fechar turma ---");

            try
            {
                Console.Write("Insira o ID da turma: ");
                int id = utilFuncs.EntrarId();

                _turmaService.FecharTurma(id);

                Console.WriteLine("\n[Sucesso] Turma fechada!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public void MostrarTodasAsTurmas()
        {
            Console.WriteLine("\n--- Buscar todas as turmas ---");

            List<Turma> turmas = _turmaService.ListarTodasAsTurmas();

            if (turmas.Count == 0)
            {
                Console.WriteLine("Nenhuma turma cadastrada.");
                return;
            }

            foreach (Turma t in turmas)
            {
                string isExcluded = t.Excluida ? "Excluída" : "Não Excluída";

                Console.WriteLine(
                    $" - ID turma: {t.idTurma}" +
                    $" - {t.local}" +
                    $" - {isExcluded}\n");

                if (t.professor != null)
                {
                    Console.WriteLine($"- {t.professor}");
                }
            }
            Console.WriteLine("______________________________");
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public void MatricularAluno()
        {
            Console.WriteLine("\n--- Matricular aluno ---");

            try
            {
                Console.Write("Insira o ID do aluno: ");
                int idAluno = utilFuncs.EntrarId();

                Console.Write("Insira o ID da turma: ");
                int idTurma = utilFuncs.EntrarId();

                _turmaService.MatricularAluno(idAluno, idTurma);

                Console.WriteLine($"\n[Sucesso] Aluno {idAluno} matriculado na turma {idTurma}!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////
        public void DesignarProfessor()
        {
            Console.WriteLine("\n--- Designar professor ---");

            try
            {
                Console.Write("Insira o ID do professor: ");
                int idProfessor = utilFuncs.EntrarId();

                Console.Write("Insira o ID da turma: ");
                int idTurma = utilFuncs.EntrarId();

                _turmaService.DesignarProfessor(idProfessor, idTurma);

                Console.WriteLine($"\n[Sucesso] Professor {idProfessor} designado à turma {idTurma}!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public void MostrarPauta()
        {
            Console.WriteLine("\n--- Pauta da turma ---");

            try
            {
                Console.Write("Insira o ID da turma: ");
                int id = utilFuncs.EntrarId();

                List<Aluno> alunos = _turmaService.ExibirPauta(id);

                Console.WriteLine($"Alunos matriculados ({alunos.Count}):");

                foreach (Aluno a in alunos)
                {
                    Console.WriteLine($"- {a}");
                    Console.WriteLine($"______");
                }
                Console.WriteLine("__________________________");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}