//using SCA_Console.Data;
using Microsoft.EntityFrameworkCore;
using SCA_Console.Data;
using SCA_Console.Models;

namespace SCA_Console.Repository
{
    public class DisciplinaRepository
    {
        private readonly ScaDBContext _context;
        public DisciplinaRepository(ScaDBContext context)
            { _context = context; }

        //////////////////////////////////////////////////////////////////////////

        public void CriarDisciplina(Disciplina disciplina)
        {
            _context.Disciplinas.Add(disciplina);
            _context.SaveChanges();
        }

        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////

        public void ExcluirDisciplina(int id)
        {
            Disciplina disciplina = BuscarDisciplina(id);
            if (disciplina != null)
            {
                disciplina.Excluido = true;
                AlterarDisciplina(disciplina);
            }
        }

        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////

        public Disciplina? BuscarDisciplina(int id)
        {
            return _context.Disciplinas
                            .Include(d => d.turmas)
                            .FirstOrDefault(d => d.idDisciplina == id);
        }

        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////

        public List<Disciplina> ListarDisciplinas()
        {
            return _context.Disciplinas.ToList();
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

            return new List<Turma>();
        }

        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////
        public void AlterarDisciplina(Disciplina disciplina)
        {
            _context.Disciplinas.Update(disciplina);
            _context.SaveChanges();
        }
    }
}
