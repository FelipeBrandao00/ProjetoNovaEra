using System.Text.Json;
using System.Net.Http.Headers;
using Application.Responses;
using WEB.Models.Response;

namespace WEB.Models.Shared {
    public class ListarCargoViewModel : ListarPadraoViewModel {
        public override string TipoItem { get; set; } = "Cargo";

        public override async Task<bool> GerarLista(IConfiguration configuration) {
            using (var client = new HttpClient()) {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/Cargo?";

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
                    var responseData = JsonSerializer.Deserialize<ResponseModelListaPadrao<ResponseModelCargo>>(responseBody, options);

                    if (responseData == null || !responseData.IsSuccess)
                        return false;

                    this.PaginaAtual = responseData.currentPage;
                    this.PaginaTotal = responseData.totalPages;
                    this.TamanhoPagina = responseData.pageSize;
                    this.TotalItens = responseData.totalCount;
                    this.ItensLista = responseData.Data?.Select(cargo => new ItemListaPadrao {
                        Id = cargo.CdCargo.ToString(),
                        Text = cargo.DsCargo
                    }).ToList() ?? new List<ItemListaPadrao>();

                    return true;
                } catch (Exception ex) {
                    return false;
                }
            }
        }
    }
}
