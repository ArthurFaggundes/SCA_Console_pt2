//using SCA_Console.Data;
using Microsoft.EntityFrameworkCore;
using SCA_Console.Data;
using SCA_Console.Models;
using SCA_Console.UI;

namespace SCA_Console.Repository
{
    public class ProfessorRepository
    {
        private readonly ScaDBContext _context;

        public ProfessorRepository(ScaDBContext context)
            {  _context = context; }

        //////////////////////////////////////////////////////////////////////////

        public void CriarProfessor(Professor professor)
        {
            _context.Professores.Add(professor);
            _context.SaveChanges();
        }

        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////

        public void ExcluirProfessor(int id)
        {
            Professor professor = BuscarProfessor(id);
            if (professor != null)
            {
                professor.Excluido = true;
                AlterarProfessor(professor);
            }
        }

        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////

        public List<Turma> ConsultarTurmas(int id)
        {
            Professor professor = BuscarProfessor(id);
            if (professor != null)
            {
                return professor.turmas.ToList();
            }
            return new List<Turma>();
        }

        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////

        public List<Professor> ListarProfessores()
        {
            return _context.Professores.ToList(); //! ESSE A PRINCIPIO NÃO PRECISA DO INCLUDE
        }

        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////

        public Professor? BuscarProfessor(int id)
        {
            return _context.Professores
                            .Include(p => p.turmas)
                            .FirstOrDefault(p => p.idProfessor == id);
        }

        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////
        public void AlterarProfessor(Professor prof)
        {
            _context.Professores.Update(prof);
            _context.SaveChanges();
        }
    }
}
