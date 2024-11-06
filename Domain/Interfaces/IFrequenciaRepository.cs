using Domain.Entities;

namespace Domain.Interfaces {
    public interface IFrequenciaRepository {
        Task<Frequencia> AddFrequencia(Frequencia frequencia);
        Task<Frequencia> DeleteFrequencia(Frequencia frequencia);
        Task<List<Frequencia>> GetFrequenciasByAulaId(int aulaId);
        Task<List<Frequencia>> AddFrequencias(int cdAula,List<Frequencia> frequencias);
    }
}
 