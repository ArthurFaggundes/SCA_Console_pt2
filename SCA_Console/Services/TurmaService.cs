using Microsoft.EntityFrameworkCore;
using SCA_Console.Models;
using SCA_Console.Repository;
using SCA_Console.UI;

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
            if (turma == null)
            {
                throw new ArgumentException("\n[Erro] turma não pode ser nula.");
            }
            if (turma.idTurma < 0) // No caso não tem como gerar isso já que é criado automaticamente mas tá aí pq precisa
            {
                throw new ArgumentException("\n[Erro] ID da turma é inválido.");
            }
            if (_turmaRepository.BuscarTurma(turma.idTurma) != null)
            {
                throw new ArgumentException("\n[Erro] Já existe uma turma com esse ID.");
            }
            if (string.IsNullOrWhiteSpace(turma.local) || turma.local.Length <= 2)
            {
                throw new ArgumentException("\n[Erro] turma deve conter um local válido.");
            }

            turma.Abrir(); //? VERIFICAR SE É ISSO MESMO QUE TEM QUE COLOCAR

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
                throw new KeyNotFoundException("\n[Erro] Turma não encontrada.");
            }
            if (turma.aberta)
            {
                throw new InvalidOperationException(
                    "\n[Erro] Não é permitido excluir uma turma aberta.");
            }

            //? Remove a referência da turma dos alunos matriculados, não sei se precisa mas botei
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
            Aluno? aluno = _alunoRepository.BuscarAluno(idAluno);
            Turma? turma = _turmaRepository.BuscarTurma(idTurma);

            if (aluno == null)
            {
                throw new KeyNotFoundException("\n[Erro] Aluno não encontrado.");
            }
            if (turma == null)
            {
                throw new KeyNotFoundException("\n[Erro] Turma não encontrada.");
            }
            if (turma.alunos.Any(a => a.idAluno == idAluno))
            {
                throw new ArgumentException("\n[Erro] Aluno já está matriculado nesta turma.");
            }
            if (turma.Excluida == true)
            {
                throw new ArgumentException("\n[Erro] A turma não pode estar excluída.");
            }
            if (aluno.Excluido == true)
            {
                throw new ArgumentException("\n[Erro] O aluno não pode estar excluído.");
            }

            // Atualiza os dos dois relacionamentos, é tipo uma tabela n:n
            turma.alunos.Add(aluno);
            aluno.turmas.Add(turma);

            _alunoRepository.AlterarAluno(aluno);
            _turmaRepository.AlterarTurma(turma);
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////
        public void DesignarProfessor(int idProfessor, int idTurma)
        {
            Professor? professor = _professorRepository.BuscarProfessor(idProfessor);
            Turma?     turma = _turmaRepository.BuscarTurma(idTurma);

            if (professor == null)
            {
                throw new KeyNotFoundException("\n[Erro] Professor não encontrado.");
            }
            if (turma == null)
            {
                throw new KeyNotFoundException("\n[Erro] Turma não encontrada.");
            }
            if (turma.professor == professor)
            {
                throw new ArgumentException("\n[Erro] Professor já está designado para esta turma.");
            }
            if (turma.Excluida == true)
            {
                throw new ArgumentException("\n[Erro] A turma não pode estar excluída.");
            }
            if (professor.Excluido == true)
            {
                throw new ArgumentException("[Erro] O professor não pode estar excluído.");
            }

            professor.turmas.Add(turma);
            turma.professor = professor;

            _professorRepository.AlterarProfessor(professor);
            _turmaRepository.AlterarTurma(turma);
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////
        public void AtribuirDisciplina(int idDsiciplina, int idTurma)
        {
            Disciplina? disciplina = _disciplinaRepository.BuscarDisciplina(idDsiciplina);
            Turma? turma = _turmaRepository.BuscarTurma(idTurma);

            if (disciplina == null)
            {
                throw new KeyNotFoundException("[Erro] Disciplina não encontrada.");
            }
            if (turma == null)
            {
                throw new KeyNotFoundException("[Erro] Turma não encontrada.");
            }
            if (turma.disciplina != null)
            {
                throw new ArgumentException("[Erro] Disciplina já atribuida a essa turma.");
            }
            if (turma.Excluida == true)
            {
                throw new ArgumentException("[Erro] A turma não pode estar excluída.");
            }

            turma.disciplina = disciplina;
            disciplina.turmas.Add(turma);

            _disciplinaRepository.AlterarDisciplina(disciplina);
            _turmaRepository.AlterarTurma(turma);
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
            _turmaRepository.AlterarTurma(turma);
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
            _turmaRepository.AlterarTurma(turma);
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
