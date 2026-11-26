using SCA_Console.Models;
using SCA_Console.Repository;


namespace SCA_Console.Services
{
    public class DisciplinaService
    {
        private DisciplinaRepository _disciplinaRepository;

        public DisciplinaService(DisciplinaRepository disciplinaRepository)
            { _disciplinaRepository = disciplinaRepository; }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public void CriarDisciplina(Disciplina disciplina)
        {
            if (disciplina.idDisciplina < 0)
            {
                throw new ArgumentException("\n[Erro] ID da disciplina é inválido.");
            }
            if (_disciplinaRepository.BuscarDisciplina(disciplina.idDisciplina) != null)
            {
                throw new ArgumentException("\n[Erro] Já existe uma disciplina com esse ID.");
            }
            if (string.IsNullOrWhiteSpace(disciplina.nome))
            {
                throw new ArgumentException("\n[Erro] nome não pode ser nulo ou em branco");
            }
            if (disciplina.nome.Length <= 2)
            {
                throw new ArgumentException("\n[Erro] nome tem que ter mais de dois caracteres");
            }

            _disciplinaRepository.CriarDisciplina(disciplina);
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public void ExcluirDisciplina(int idDisciplina)
        {
            Disciplina disciplina = _disciplinaRepository.BuscarDisciplina(idDisciplina);

            if (disciplina == null)
            {
                throw new KeyNotFoundException("\n[Erro] Disciplina não encontrada.");
            }

            _disciplinaRepository.ExcluirDisciplina(idDisciplina);
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public List<Disciplina> ListarDisciplinas()
        {
            return _disciplinaRepository.ListarDisciplinas();
            // da pra encaixar verificiações e precisar
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public List<Turma> MostrarTurmasDaDisciplina(int id)
        {
            List<Turma> turmas = _disciplinaRepository.ConsultarTurmas(id);

            if (turmas == null)
            {
                throw new KeyNotFoundException("\n[Erro] Nenhuma turma encontrada.");
            }

            return turmas;
        }
    }
}
