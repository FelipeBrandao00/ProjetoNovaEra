using API_NOVA_ERA.Database;
using Domain.Entities;
using Domain.Interfaces;

namespace Infra.Data.Repositories {
    public class ProfessorRepository : IProfessorRepository {

        private ApplicationDbContext _ProfessorContext;
        public ProfessorRepository(ApplicationDbContext context) {
            _ProfessorContext = context;
        }

        public Task<Professor> CreateProfessorAsync(Professor professor) {
            throw new NotImplementedException();
        }

        public Task<Professor> DeleteProfessorAsync(Professor professor) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Professor>> GetAllProfessorsAsync() {
            throw new NotImplementedException();
        }

        public Task<Professor> GetProfessorAsync(int id) {
            throw new NotImplementedException();
        }

        public Task<Professor> UpdateProfessorAsync(Professor professor) {
            throw new NotImplementedException();
        }
    }
}
