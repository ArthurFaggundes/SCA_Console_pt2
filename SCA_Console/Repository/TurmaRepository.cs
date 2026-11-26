using Microsoft.EntityFrameworkCore;
using SCA_Console.Data;
using SCA_Console.Models;

namespace SCA_Console.Repository
{
    public class TurmaRepository
    {
        private readonly ScaDBContext _context;
        public TurmaRepository(ScaDBContext context)
            { _context = context; }

        public void CriarTurma(Turma turma)
        {
            _context.Turmas.Add(turma);
            _context.SaveChanges(); 
        }

        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////

        public void ExcluirTurma(int id)
        {
            Turma turma = BuscarTurma(id);

            if (turma != null)
            {
                turma.Excluida = true;
                AlterarTurma(turma);
            }
        }

        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////

        public List<Turma> ListarTurmas()
        {
            return _context.Turmas
                    .Include(t => t.professor)
                    .Include(t => t.disciplina)
                    .ToList();
        }

        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////
        public Turma? BuscarTurma(int id)
        {
            return _context.Turmas
                    .Include(t => t.professor)
                    .Include(t => t.disciplina)
                    .FirstOrDefault(t => t.idTurma == id);
        }

        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////
        public void AlterarTurma(Turma turma)
        {
            _context.Turmas.Update(turma);
            _context.SaveChanges();
        }
    }
}
