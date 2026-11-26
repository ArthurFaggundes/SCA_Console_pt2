using System.ComponentModel.DataAnnotations;

namespace SCA_Console.Models
{
    public class Professor
    {
        [Key]
        public int idProfessor { get; set; }
        public string nome { get; set; }

        public List<Turma> turmas { get; set; } = new();

        public bool Excluido { get; set; } = false;

        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////

        public Professor() {}

        public Professor(string nome)
        {
            this.nome = nome;
        }

        public override string ToString() 
        {
            string isExcluded = Excluido ? "Excluído" : "Não Excluído";

            return $"ID: {idProfessor} || Nome: {nome} || Status: {isExcluded}";
        }
    }
}
