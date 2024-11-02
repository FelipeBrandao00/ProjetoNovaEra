using Application.Responses;
using System.Net.Http.Headers;
using System.Text.Json;

namespace WEB.Models.Shared {
    public class ListarTurmaViewModel : ListarPadraoViewModel {
        public override string TipoItem { get; set; } = "Turma";
        public DateTime? DtInicial { get; set; }
        public DateTime? DtFinal { get; set; }
        public bool? IcFinalizado { get; set; }
        public int? CursoId { get; set; }

        public override async Task<bool> GerarLista(IConfiguration configuration) {
            using (var client = new HttpClient()) {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/Turma?";

                if (!string.IsNullOrEmpty(this.Busca)) {
                    url += $"nome={this.Busca}&";
                }
                if (this.DtInicial != null) {
                    url += $"dtInicial={String.Format("{0:MM-dd-yyyy}", this.DtInicial)}&";
                }
                if (this.DtFinal != null) {
                    url += $"dtFinal={String.Format("{0:MM-dd-yyyy}", this.DtFinal)}&";
                }
                if (this.IcFinalizado != null) {
                    url += $"icFinalizado={this.IcFinalizado}&";
                }
                if (this.CursoId != null) {
                    url += $"cursoId={this.CursoId}&";
                }
                url += $"pageNumber={this.PaginaAtual}&pageSize={this.TamanhoPagina}";

                var token = configuration["JwtToken"];
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try {
                    var response = await client.GetAsync(url);
                    if (!response.IsSuccessStatusCode)
                        return false;

                    var responseBody = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var responseData = JsonSerializer.Deserialize<ResponseModelListaPadrao<ResponseModelTurma>>(responseBody, options);

                    if (responseData == null || !responseData.IsSuccess)
                        return false;

                    this.PaginaAtual = responseData.currentPage;
                    this.PaginaTotal = responseData.totalPages;
                    this.TamanhoPagina = responseData.pageSize;
                    this.TotalItens = responseData.totalCount;
                    this.ItensLista = responseData.Data?.Select(turma => new ItemListaPadrao {
                        Id = turma.CdTurma.ToString(),
                        Text = turma.NmTurma
                    }).ToList() ?? new List<ItemListaPadrao>();

                    return true;
                } catch (Exception ex) {
                    return false;
                }
            }
        }
    }
}
