using SCA_Console.Models;
using SCA_Console.Repository;

namespace SCA_Console.Services
{
    public class AlunoService
    {
        private AlunoRepository _alunoRepository;

        public AlunoService(AlunoRepository alunoRepository)
            { _alunoRepository = alunoRepository; } // faz com que todo o Cód. compartilhe a lista

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public void CriarAluno(Aluno aluno)
        {
            if (aluno.idAluno < 0)
            {
                throw new ArgumentException("[Erro] ID do aluno é inválido.");
            }
            if (_alunoRepository.BuscarAluno(aluno.idAluno) != null)
            {
                throw new ArgumentException("[Erro] Já existe um aluno com esse ID.");
            }
            if (string.IsNullOrWhiteSpace(aluno.nome))
            {
                throw new ArgumentException("[Erro] nome não pode ser nulo ou em branco");
            }
            if (aluno.nome.Length <= 2)
            {
                throw new ArgumentException("[Erro] nome tem que ter mais de dois caracteres");
            }

            _alunoRepository.CriarAluno(aluno);
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public void ExcluirAluno(int idAluno)
        {
            Aluno aluno = _alunoRepository.BuscarAluno(idAluno);

            if (aluno == null)
            {
                throw new KeyNotFoundException("[Erro] Aluno não encontrado.");
            }

            _alunoRepository.ExcluirAluno(idAluno);
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public List<Aluno> ListarAlunos()
        {
            return _alunoRepository.ListarAlunos();
            // da pra encaixar verificiações e precisar
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public int MostrarCreditosAtuais(int idAluno)
        {
            Aluno aluno = _alunoRepository.BuscarAluno(idAluno);
            int credAtuais = _alunoRepository.MostrarCreditosAtuais(idAluno);

            if (aluno == null)
            {
                throw new KeyNotFoundException("[Erro] Aluno não encontrado.");
            }
            return credAtuais;
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public List<Turma> MostrarTurmasDoAluno(int id)
        {
            Aluno aluno = _alunoRepository.BuscarAluno(id);
            List<Turma> turmas = _alunoRepository.ConsultarTurmas(id);

            if (aluno == null)
            {
                throw new KeyNotFoundException("[Erro] Aluno não encontrado.");
            }
            if (turmas == null || turmas.Count == 0)
            {
                throw new KeyNotFoundException("[Erro] Nenhuma turma encontrada.");
            }

            return turmas;
        }
    }
}
