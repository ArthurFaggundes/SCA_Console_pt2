//using Microsoft.EntityFrameworkCore;
//using SCA_ProjBackEnd.Data;
using Microsoft.EntityFrameworkCore;
using SCA_Console.Data;
using SCA_Console.Models;

namespace SCA_Console.Repository
{
    public class AlunoRepository
    {
        private readonly ScaDBContext _context;
        public AlunoRepository(ScaDBContext context) 
            { _context = context; }

        //////////////////////////////////////////////////////////////////////////

        public void CriarAluno(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            _context.SaveChanges();
        }

        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////

        public void ExcluirAluno(int id)
        {
            Aluno aluno = BuscarAluno(id);
            if (aluno != null)
            {
                aluno.Excluido = true;
                AlterarAluno(aluno);
            }
        }

        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////

        public int MostrarCreditosAtuais(int id)
        {
            Aluno aluno = BuscarAluno(id);
            if (aluno != null)
            {
                return aluno.numCredAtuais;
            }
            return 0;
        }

        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////
        
        public List<Aluno> ListarAlunos()
        {
            return _context.Alunos.ToList();
        }

        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////

        public Aluno? BuscarAluno(int id)
        {
            return _context.Alunos
                            .Include(a => a.turmas)
                            .FirstOrDefault(a => a.idAluno == id);
        }

        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////

        public List<Turma> ConsultarTurmas(int id)
        {
            Aluno aluno = BuscarAluno(id);
            if (aluno != null)
            {
                return aluno.turmas.ToList();
            }
            return new List<Turma>();
        }

        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////
        public void AlterarAluno(Aluno aluno)
        {
            _context.Alunos.Update(aluno);
            _context.SaveChanges();
        }
    }
}
