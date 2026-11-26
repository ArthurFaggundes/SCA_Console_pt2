 using System.ComponentModel.DataAnnotations;

namespace SCA_Console.Models
{
    public class Aluno
    {
        [Key]
        public int idAluno { get; set; }
        public string nome { get; set; }
        public List<Turma> turmas { get; set; } = new();
        public int numCredAtuais { get; set; } = 0;

        public bool Excluido { get; set; } = false;

        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////

        // Para o banco de dados, é necessário ter um construtor sem parâmetros para que o Entity Framework possa instanciar a classe corretamente.
        public Aluno() {}

        public Aluno(string nome) 
        { 
            this.nome = nome;
        }

        public override string ToString() 
        { 
            string isExcluded = Excluido ? "Excluído" : "Não Excluído";

            return $"ID: {idAluno} || Nome: {nome} || Status: {isExcluded}";
        }

        public void IncrementarCredito(int numCredito) //? Talvez colocar isso em Service!!!!!
        {
            this.numCredAtuais += numCredito;
        }
    }
}
