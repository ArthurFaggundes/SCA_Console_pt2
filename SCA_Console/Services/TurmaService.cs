using SCA_Console.Models;
using SCA_Console.Repository;

namespace SCA_Console.Services
{
    public class TurmaService
    {
        private readonly TurmaRepository _turmaRepository;
        private readonly AlunoRepository _alunoRepository;
        private readonly ProfessorRepository _professorRepository;
        private readonly DisciplinaRepository _disciplinaRepository;

        public TurmaService
            (TurmaRepository turmaRepository, AlunoRepository alunoRepository, ProfessorRepository professorRepository, DisciplinaRepository disciplinaRepository)
        {
            _turmaRepository = turmaRepository;
            _alunoRepository = alunoRepository;
            _professorRepository = professorRepository;
            _disciplinaRepository = disciplinaRepository;
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public void CriarTurma(Turma turma)
        {
            if (turma.idTurma < 0)
            {
                throw new ArgumentException("[Erro] ID da turma é inválido.");
            }
            if (_turmaRepository.BuscarTurma(turma.idTurma) != null)
            {
                throw new ArgumentException("[Erro] Já existe uma turma com esse ID.");
            }
            if (turma == null)
            {
                throw new ArgumentException("[Erro] turma não pode ser nula.");
            }
            if (string.IsNullOrWhiteSpace(turma.local) || turma.local.Length <= 2)
            {
                throw new ArgumentException("[Erro] turma deve conter um local válido.");
            }

            turma.Abrir(); 

            _turmaRepository.CriarTurma(turma);
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public List<Turma> ListarTodasAsTurmas()
        {
            return _turmaRepository.ListarTurmas();
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public void ExcluirTurma(int idTurma)
        {
            Turma turma = _turmaRepository.BuscarTurma(idTurma);

            if (turma == null)
            {
                throw new KeyNotFoundException("[Erro] Turma não encontrada.");
            }
            if (turma.aberta)
            {
                throw new InvalidOperationException(
                    "[Erro] Não é permitido excluir uma turma aberta.");
            }

            //? Remove a referência da turma dos alunos matriculados.
            foreach (Aluno a in turma.alunos)
            {
                a.turmas.Remove(turma);
            }

            _turmaRepository.ExcluirTurma(idTurma);
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public void MatricularAluno(int idAluno, int idTurma)
        {
            Aluno aluno = _alunoRepository.BuscarAluno(idAluno);
            Turma turma = _turmaRepository.BuscarTurma(idTurma);

            if (aluno == null)
            {
                throw new KeyNotFoundException("[Erro] Aluno não encontrado.");
            }
            if (turma == null)
            {
                throw new KeyNotFoundException("[Erro] Turma não encontrada.");
            }
            if (turma.alunos.Any(a => a.idAluno == idAluno))
            {
                throw new ArgumentException("[Erro] Aluno já está matriculado nesta turma.");
            }
            if (turma.Excluida == true)
            {
                throw new ArgumentException("[Erro] A turma não pode estar excluída.");
            }
            if (aluno.Excluido == true)
            {
                throw new ArgumentException("[Erro] O aluno não pode estar excluído.");
            }

            // Atualiza os dos dois relacionamentos, é tipo uma tabela n:n
            turma.alunos.Add(aluno);
            aluno.turmas.Add(turma);
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////
        public void DesignarProfessor(int idProfessor, int idTurma)
        {
            Professor professor = _professorRepository.BuscarProfessor(idProfessor);
            Turma turma = _turmaRepository.BuscarTurma(idTurma);

            if (professor == null)
            {
                throw new KeyNotFoundException("[Erro] Professor não encontrado.");
            }
            if (turma == null)
            {
                throw new KeyNotFoundException("[Erro] Turma não encontrada.");
            }
            if (turma.professor == professor)
            {
                throw new ArgumentException("[Erro] Professor já está designado para esta turma.");
            }
            if (turma.Excluida == true)
            {
                throw new ArgumentException("[Erro] A turma não pode estar excluída.");
            }
            if (professor.Excluido == true)
            {
                throw new ArgumentException("[Erro] O professor não pode estar excluído.");
            }

            turma.professor = professor;
            professor.turmas.Add(turma);
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public void AbrirTurma(int idTurma)
        {
            Turma turma = _turmaRepository.BuscarTurma(idTurma);

            if (turma == null)
            {
                throw new KeyNotFoundException("[Erro] Turma não encontrada.");
            }
            if (turma.aberta)
            {
                throw new ArgumentException("[Erro] Turma já está aberta.");
            }
            if (turma.alunos.Count < 2)
            {
                throw new ArgumentException("[Erro] Turma deve ter no mínimo dois alunos.");
            }
            if (turma.professor == null)
            {
                throw new ArgumentException("[Erro] Turma deve ter um professor atribuído.");
            }
            if (turma.disciplina == null)
            {
                throw new ArgumentException("[Erro] Turma deve ter uma disciplina atribuída.");
            }
            if (turma.Excluida == true)
            {
                throw new ArgumentException("[Erro] Não é possível abrir uma turma excluída.");
            }

            turma.Abrir();
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public void FecharTurma(int idTurma)
        {
            Turma turma = _turmaRepository.BuscarTurma(idTurma);

            if (turma == null)
            {
                throw new KeyNotFoundException("[Erro] Turma não encontrada.");
            }

            turma.Fechar();
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public List<Aluno> ExibirPauta(int idTurma) // Exibir alunos
        {
            Turma turma = _turmaRepository.BuscarTurma(idTurma);

            if (turma == null || turma.Excluida == true)
            {
                throw new KeyNotFoundException("[Erro] Turma não foi encontrada.");
            }

            return turma.alunos;
        }
    }
}
