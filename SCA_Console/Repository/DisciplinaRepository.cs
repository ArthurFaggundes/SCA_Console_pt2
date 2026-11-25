//using SCA_Console.Data;
using SCA_Console.Models;

namespace SCA_Console.Repository
{
    public class DisciplinaRepository
    {
        //private readonly SCAdbContext _context;

        //public DisciplinaRepository(SCAdbContext context)
        //{
        //    _context = context;
        //}

        public readonly List<Disciplina> listaDisciplinas = new List<Disciplina>();

        public void CriarDisciplina(Disciplina disciplina)
        {
            listaDisciplinas.Add(disciplina);
        }

        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////

        public void ExcluirDisciplina(int id)
        {
            Disciplina disciplina = BuscarDisciplina(id);
            if (disciplina != null)
            {
                disciplina.Excluido = true;
            }
        }

        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////

        public Disciplina BuscarDisciplina(int id)
        {
            return listaDisciplinas.FirstOrDefault(d => d.idDisciplina == id)!;
        }

        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////

        public List<Disciplina> ListarDisciplinas()
        {
            return listaDisciplinas;
        }

        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////

        public List<Turma> ConsultarTurmas(int id)
        {
            Disciplina disciplina = BuscarDisciplina(id);
            if (disciplina != null)
            {
                return disciplina.turmas;
            }

            return null!;
        }
    }
}
