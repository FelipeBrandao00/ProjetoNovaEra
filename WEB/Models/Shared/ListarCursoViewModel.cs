using System.Text.Json;
using System.Net.Http.Headers;

namespace WEB.Models.Shared {
    public class listarCursoViewModel : ListarPadraoViewModel {
        public override string TipoItem { get; set; } = "Curso";
        public DateTime? dtInicial { get; set; }
        public DateTime? dtFinal { get; set; }
        public bool? icFinalizado { get; set; }

        public override async Task<bool> GerarLista(IConfiguration configuration) {
            using (var client = new HttpClient()) {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/Curso?";

                if (!string.IsNullOrEmpty(this.Busca)) {
                    url += $"nome={this.Busca}&";
                }
                if (this.dtInicial != null) {
                    url += $"dtInicial={this.dtInicial}&";
                }
                if (this.dtFinal != null) {
                    url += $"dtFinal={this.dtFinal}&";
                }
                if (this.icFinalizado != null) {
                    url += $"icFinalizado={this.icFinalizado}&";
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
                    var responseData = JsonSerializer.Deserialize<ResponseModelListaCurso>(responseBody, options);

                    if (responseData == null || !responseData.IsSuccess)
                        return false;

                    this.PaginaAtual = responseData.currentPage;
                    this.PaginaTotal = responseData.totalPages;
                    this.TamanhoPagina = responseData.pageSize;
                    this.TotalItens = responseData.totalCount;
                    this.ItensLista = responseData.Data?.Select(curso => new ItemListaPadrao {
                        Id = curso.CdCurso.ToString(),
                        Text = curso.NmCurso
                    }).ToList() ?? new List<ItemListaPadrao>();

                    return true;
                } catch (Exception ex) {
                    return false;
                }
            }
        }
    }
}
