using Microsoft.AspNetCore.Mvc;

namespace WEB.Models.Inscricao {
    public class InscricaoViewModel {
        public string DsNome { get; set; }
        public string DsEmail { get; set; }
        public string DsCPF { get; set; }
        public int CdGenero { get; set; }
        public DateTime? DtNascimento { get; set; }
        public string DsTelefone { get; set; }
        public int CdCurso { get; set; }
    }
}
