using Microsoft.EntityFrameworkCore;

using SCA_Console.Repository;
using SCA_Console.Services;
using SCA_Console.UI;

public class Program
{
    static void Main(string[] args)
    {
        AlunoRepository alunoRepository = new();
        AlunoService alunoService = new(alunoRepository);
        AlunoUI alunoUI = new(alunoService);

        ProfessorRepository professorRepository = new();
        ProfessorService professorService = new(professorRepository);
        ProfessorUI professorUI = new(professorService);

        DisciplinaRepository disciplinaRepository = new();
        DisciplinaService disciplinaService = new(disciplinaRepository);
        DisciplinaUI disciplinaUI = new(disciplinaService);

        TurmaRepository turmaRepository = new();
        TurmaService turmaService = new(turmaRepository, alunoRepository, professorRepository, disciplinaRepository);
        TurmaUI turmaUI = new(turmaService);

        Console.WriteLine("Bem-vindo(a)!");
        while (true)
        {
            Console.WriteLine("\n+-------------------------------------------+");
            Console.WriteLine("|   Qual categoria você deseja trabalhar?   |");
            Console.WriteLine("+-------------------------------------------+");
            Console.WriteLine("a. Alunos");
            Console.WriteLine("b. Turmas");
            Console.WriteLine("c. Professores");
            Console.WriteLine("d. Disciplinas");
            Console.WriteLine("x. Sair");
            Console.WriteLine();
            Console.Write("[CATEGORIA]: ");
            string? escolhaCategoria = Console.ReadLine();
            string? subOpcao = null;

            switch (escolhaCategoria)
            {
                case "a": // ALUNOS
                    Console.WriteLine("\n=== O que deseja fazer? ===");
                    Console.WriteLine("1. Criar novo Aluno");
                    Console.WriteLine("2. Excluir Aluno");
                    Console.WriteLine("3. Mostrar todos os alunos de todas as turmas");
                    Console.WriteLine("4. Mostrar todas as turmas de um aluno");
                    Console.WriteLine("5. Mostrar créditos atuais de um aluno");
                    Console.WriteLine("0. Voltar");
                    Console.WriteLine();
                    Console.Write("[OPÇÃO]: ");
                    subOpcao = Console.ReadLine();

                        switch (subOpcao)
                        {
                            case "1": alunoUI.CriarNovoAluno();        break;
                            case "2": alunoUI.ExcluirAluno();          break;
                            case "3": alunoUI.MostrarTodosOsAlunos();  break;
                            case "4": alunoUI.MostrarTurmasDoAluno();  break;
                            case "5": alunoUI.MostrarCreditosAtuais(); break;

                            case "0":
                                Console.WriteLine("\nVoltando..."); break;
                            default:
                                Console.WriteLine("\nOpção inválida. Tente novamente."); break;
                        }
                    break;
                ////////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////

                case "b": // TURMAS
                    Console.WriteLine("\n=== O que deseja fazer? ===");
                    Console.WriteLine("1. Criar nova Turma");
                    Console.WriteLine("2. Excluir Turma");
                    Console.WriteLine("3. Abrir turma");
                    Console.WriteLine("4. Fechar turma");
                    Console.WriteLine("5. Mostrar todas as turmas");
                    Console.WriteLine("6. Mostrar pauta da turma");
                    Console.WriteLine("7. Matricular um aluno a uma turma");
                    Console.WriteLine("8. Designar um professor a uma turma");
                    Console.WriteLine("0. Voltar");
                    Console.WriteLine();
                    Console.Write("[OPÇÃO]: ");
                    subOpcao = Console.ReadLine();

                        switch (subOpcao)
                        {
                            case "1": turmaUI.CriarNovaTurma();       break;
                            case "2": turmaUI.ExcluirTurma();         break;
                            case "3": turmaUI.AbrirTurma();           break;
                            case "4": turmaUI.FecharTurma();          break;
                            case "5": turmaUI.MostrarTodasAsTurmas(); break;
                            case "6": turmaUI.MostrarPauta();         break;
                            case "7": turmaUI.MatricularAluno();      break;
                            case "8": turmaUI.DesignarProfessor();    break;

                            case "0":
                                Console.WriteLine("\nVoltando..."); break;
                            default:
                                Console.WriteLine("\nOpção inválida. Tente novamente."); break;
                        }
                    break;
                ////////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////

                case "c": // PROFESSORES
                    Console.WriteLine("\n=== O que deseja fazer? ===");
                    Console.WriteLine("1. Criar novo Professor");
                    Console.WriteLine("2. Excluir Professor");
                    Console.WriteLine("3. Mostrar todos os professores");
                    Console.WriteLine("4. Mostrar todas as turmas de um professor");
                    Console.WriteLine("0. Voltar");
                    Console.WriteLine();
                    Console.Write("[OPÇÃO]: ");
                    subOpcao = Console.ReadLine();

                    switch (subOpcao)
                    {
                        case "1": professorUI.CriarNovoProfessor();        break;
                        case "2": professorUI.ExcluirProfessor();          break;
                        case "3": professorUI.MostrarTodosOsProfessores(); break;
                        case "4": professorUI.MostrarTurmasDoProfessor();  break;

                        case "0":
                            Console.WriteLine("\nVoltando..."); break;
                        default:
                            Console.WriteLine("\nOpção inválida. Tente novamente."); break;
                    }
                    break;
                ////////////////////////////////////////////////////////////
                ////////////////////////////////////////////////////////////
                
                case "d": // DISCIPLINAS
                    Console.WriteLine("\n=== O que deseja fazer? ===");
                    Console.WriteLine("1. Criar nova Disciplina");
                    Console.WriteLine("2. Excluir Disciplina");
                    Console.WriteLine("3. Mostrar todas as disciplinas");
                    Console.WriteLine("4. Mostrar todas as turmas de uma disciplina");
                    Console.WriteLine("0. Voltar");
                    Console.WriteLine();
                    Console.Write("[OPÇÃO]: ");
                    subOpcao = Console.ReadLine();

                    switch (subOpcao)
                    {
                        case "1": disciplinaUI.CriarNovaDisciplina();       break;
                        case "2": disciplinaUI.ExcluirDisciplina();         break;
                        case "3": disciplinaUI.MostrarTodasAsDisciplinas(); break;
                        case "4": disciplinaUI.MostrarTurmasDaDisciplina(); break;

                        case "0":
                            Console.WriteLine("\nVoltando..."); break;
                        default:
                            Console.WriteLine("\nOpção inválida. Tente novamente."); break;
                    }
                    break;

                case "x":
                    Console.WriteLine("\nObrigado por usar o SCA do Arthur! :)");
                    return;
                default:
                    Console.WriteLine("\nOpção inválida. Tente novamente.");
                    break;
            }
        }
    }
}