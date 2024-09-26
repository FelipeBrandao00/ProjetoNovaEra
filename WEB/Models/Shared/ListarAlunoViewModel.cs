using static WEB.Models.EsqueciSenha.EsqueciSenhaViewModel;
using System.Text.Json;
using System.Text;
using Application.Responses;

namespace WEB.Models.Shared
{
    public class ListarAlunoViewModel : ListarPadraoViewModel
    {
        public override string TipoItem { get; set; } = "Aluno";

        public override async Task<bool> GerarLista(IConfiguration configuration)
        {
            using (var client = new HttpClient())
            {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/Aluno/GetAlunoByLikedName/";

                if (!string.IsNullOrEmpty(this.Busca))
                    url += $"{this.Busca}?";

                url += $"pageNumber={this.PaginaAtual}&pageSize={this.TamanhoPagina}";

                try
                {
                    var response = await client.GetAsync(url);
                    if (!response.IsSuccessStatusCode)
                        return false;

                    var responseBody = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var responseData = JsonSerializer.Deserialize<ResponseModelListaPadrao>(responseBody, options);

                    if (responseData == null || !responseData.IsSuccess)
                        return false;

                    this.PaginaAtual = responseData.PaginaAtual;
                    this.PaginaTotal = responseData.PaginaTotal;
                    this.TamanhoPagina = responseData.TamanhoPagina;
                    this.TotalItens = responseData.TotalItens;
                    this.ItensLista = responseData.Data?.Select(usuario => new ItemListaPadrao
                    {
                        Id = usuario.CdUsuario.ToString(),
                        Text = usuario.NmUsuario
                    }).ToList() ?? new List<ItemListaPadrao>();

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
