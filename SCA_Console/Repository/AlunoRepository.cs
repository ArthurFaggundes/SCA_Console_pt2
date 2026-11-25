//using Microsoft.EntityFrameworkCore;
//using SCA_ProjBackEnd.Data;
using SCA_Console.Models;

namespace SCA_Console.Repository
{
    public class AlunoRepository
    {
        //private readonly SCAdbContext _context;
        //public AlunoRepository(SCAdbContext context) {_context = context;}

        public readonly List<Aluno> listaAlunos = new();

        public void CriarAluno(Aluno aluno)
        {
            listaAlunos.Add(aluno);
            //_context.SaveChanges();
        }

        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////

        public void ExcluirAluno(int id)
        {
            Aluno aluno = BuscarAluno(id);
            if (aluno != null)
            {
                aluno.Excluido = true;
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
            return listaAlunos;
        }

        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////

        public Aluno BuscarAluno(int id)
        {
            return listaAlunos.FirstOrDefault(a => a.idAluno == id)!;
            // retorna em ordem alfabética (basicamente a função mais importante)
        }

        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////

        public List<Turma> ConsultarTurmas(int id)
        {
            Aluno aluno = BuscarAluno(id);
            if (aluno != null)
            {
                return aluno.turmas;
            }

            return null!;
        }
    }
}
