 using System.ComponentModel.DataAnnotations;

namespace SCA_Console.Models
{
    public class Turma
    {
        [Key]
        public int idTurma { get; set; }
        public string local { get; set; }
        public bool aberta { get; set; } = false;

        public List<Aluno> alunos { get; set; } = new();
        public Disciplina? disciplina { get; set; }
        public Professor? professor { get; set; }

        public bool Excluida { get; set; } = false;

        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////

        public Turma() {}

        public Turma(string local)
        {
            this.local = local;
        }

        public override string ToString() 
        {
            string isOpen = aberta ? "Turma aberta" : "Turma fechada";
            string isExcluded = Excluida ? "Excluída" : "Não Excluída";

            return $"ID: {idTurma} || Local: {local} || {isOpen} || {isExcluded}";
        }

        public void Abrir() { aberta = true; }
        public void Fechar() { aberta = false; }
    }
}