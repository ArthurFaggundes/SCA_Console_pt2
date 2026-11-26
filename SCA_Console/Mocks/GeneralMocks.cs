using SCA_Console.Models;

namespace SCA_Console.Mocks // ᓚᘏᗢ Só pra ajduar na correção
{
    public static class GeneralMocks
    {
        public static List<Aluno> GerarAlunos()
        {
            return new List<Aluno>
            {
                new Aluno("John Travolta"),
                new Aluno("Michelle Obama"),
                new Aluno("Teste da Silva")
            };
        }

        public static List<Disciplina> GerarDisciplinas()
        {
            return new List<Disciplina>
            {
                new Disciplina("Biologia computacional"),
                new Disciplina("Programação de animais"),
                new Disciplina("Medicina esotérica")
            };
        }

        public static List<Professor> GerarProfessores()
        {
            return new List<Professor>
            {
                new Professor("Fausto Silva"),
                new Professor("João Kleber"),
                new Professor("Silvio Santos")
            };
        }

        public static List<Turma> GerarTurmas()
        {
            return new List<Turma>
            {
                new Turma("Bairro hello world"),
                new Turma("Rua python"),
                new Turma("Avenida Sê Charpe")
            };
        }
    }
}