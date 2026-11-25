//using SCA_Console.Data;
using SCA_Console.Models;
using SCA_Console.UI;

namespace SCA_Console.Repository
{
    public class ProfessorRepository
    {
        //private readonly SCAdbContext _context;

        //public ProfessorRepository(SCAdbContext context)
        //{
        //    _context = context;
        //}

        public readonly List<Professor> listaProfessores = new List<Professor>();

        public void CriarProfessor(Professor professor)
        {
            listaProfessores.Add(professor);
            //_context.SaveChanges();
        }

        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////

        public void ExcluirProfessor(int id)
        {
            Professor professor = BuscarProfessor(id);
            if (professor != null)
            {
                professor.Excluido = true;
            }
            //_context.SaveChanges();
        }

        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////

        public List<Turma> ConsultarTurmas(int id)
        {
            Professor professor = BuscarProfessor(id);
            if (professor != null)
            {
                return professor.turmas;
            }
            return null!;
        }

        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////

        public List<Professor> ListarProfessores()
        {
            return listaProfessores;
        }

        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////

        public Professor BuscarProfessor(int id)
        {
            return listaProfessores.FirstOrDefault(p => p.idProfessor == id)!;
            // retorna em ordem alfabética (basicamente a função mais importante)
        }
    }
}
