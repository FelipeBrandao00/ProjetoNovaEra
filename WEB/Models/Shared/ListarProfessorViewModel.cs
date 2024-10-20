using System.Text.Json;
using System.Net.Http.Headers;
using Application.Responses;

namespace WEB.Models.Shared {
    public class ListarProfessorViewModel : ListarPadraoViewModel {
        public override string TipoItem { get; set; } = "Professor";

        public bool? IcHabilitadoTurma { get; set; } = null;

        public override async Task<bool> GerarLista(IConfiguration configuration) {
            using (var client = new HttpClient()) {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/Professor/GetProfessores?";

                url += $"pageNumber={this.PaginaAtual}&pageSize={this.TamanhoPagina}";
                if (!string.IsNullOrEmpty(this.Busca))
                    url += $"&nmProfessor={this.Busca}&";

                if (this.IcHabilitadoTurma != null) {
                    string boolLower = this.IcHabilitadoTurma.ToString().ToLower();
                    url += $"&icHabilitadoTurma={boolLower}";
                }
                    

                var token = configuration["JwtToken"];
                if (!string.IsNullOrEmpty(token))
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                try {
                    var response = await client.GetAsync(url);
                    if (!response.IsSuccessStatusCode)
                        return false;

                    var responseBody = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var responseData = JsonSerializer.Deserialize<ResponseModelListaPadrao<ResponseModelUsuario>>(responseBody, options);

                    if (responseData == null || !responseData.IsSuccess)
                        return false;

                    this.PaginaAtual = responseData.currentPage;
                    this.PaginaTotal = responseData.totalPages;
                    this.TamanhoPagina = responseData.pageSize;
                    this.TotalItens = responseData.totalCount;
                    this.ItensLista = responseData.Data?.Select(usuario => new ItemListaPadrao {
                        Id = usuario.DsCpf,
                        Text = usuario.NmUsuario
                    }).ToList() ?? new List<ItemListaPadrao>();

                    return true;
                } catch (Exception ex) {
                    return false;
                }
            }
        }
    }
}
