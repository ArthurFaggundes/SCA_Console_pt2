using System.ComponentModel.DataAnnotations;

namespace SCA_Console.Models
{ 
	public class Disciplina
	{
        [Key]
		public int idDisciplina { get; set; }
        public string nome { get; set; }
        public List<Turma> turmas { get; set; } = new();
        public bool Excluido { get; set; } = false;

        //public string cargaHoraria { get; set; }
        //public int numCreditos { get; set; }

        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////
        public Disciplina(int idDisciplina, string nome)
        {
            this.idDisciplina = idDisciplina;
            this.nome = nome;
			//this.cargaHoraria = cargaHoraria;
			//this.numCreditos = numCreditos;
            //? NO MOMENTO NÃO PRECISA POR 
        }

        public override string ToString() { 
            return $"ID: {idDisciplina} || Nome: {nome}";
        }
    }
}

