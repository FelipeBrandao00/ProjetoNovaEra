using Domain.Entities;

namespace Domain.Interfaces {
    public interface IProfessorRepository {
        Task<IEnumerable<Professor>> GetAllProfessorsAsync();
        Task<Professor> GetProfessorAsync(int id);
        Task<Professor> CreateProfessorAsync(Professor professor);
        Task<Professor> UpdateProfessorAsync(Professor professor);
        Task<Professor> DeleteProfessorAsync(Professor professor);
    }
}
