using SCA_Console.Models;
using SCA_Console.Repository;
using SCA_Console.UI;

namespace SCA_Console.Services
{
    public class ProfessorService {

        private readonly ProfessorRepository _professorRepository;

        public ProfessorService(ProfessorRepository professorRepository)
        { _professorRepository = professorRepository; }



        public void CriarProfessor(Professor prof) 
        {
            if (prof.idProfessor < 0)
            {
                throw new ArgumentException("[Erro] ID do professor é inválido.");
            }
            if (_professorRepository.BuscarProfessor(prof.idProfessor) != null)
            {
                throw new ArgumentException("[Erro] Já existe um professor com esse ID.");
            }
            if (string.IsNullOrWhiteSpace(prof.nome)) 
            {
                throw new ArgumentException("[Erro] nome não pode ser nulo ou em branco");
            }
            if (prof.nome.Length <= 2) 
            {
                throw new ArgumentException("[Erro] nome tem que ter mais de dois caracteres");
            }

            _professorRepository.CriarProfessor(prof);
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public void ExcluirProfessor(int idProfessor)
        {
            Professor prof = _professorRepository.BuscarProfessor(idProfessor);

            if (prof == null)
            {
                throw new KeyNotFoundException("[Erro] Professor não encontrado.");
            }

            _professorRepository.ExcluirProfessor(idProfessor);
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public List<Professor> ListarProfessores()
        {
            return _professorRepository.ListarProfessores();
            // da pra encaixar verificiações e precisar
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////

        public List<Turma> MostrarTurmasDoProfessor(int id)
        {
            Professor prof = _professorRepository.BuscarProfessor(id);
            List<Turma> turmas = _professorRepository.ConsultarTurmas(id);

            if (prof == null)
            {
                throw new KeyNotFoundException("[Erro] Professor não encontrado.");
            }
            if (turmas == null || turmas.Count == 0)
            {
                throw new KeyNotFoundException("[Erro] Nenhuma turma encontrada.");
            }

            return turmas;
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////
    }
}