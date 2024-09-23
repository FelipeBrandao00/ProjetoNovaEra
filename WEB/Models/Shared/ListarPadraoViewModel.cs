using static WEB.Models.EsqueciSenha.EsqueciSenhaViewModel;
using System.Text.Json;
using System.Text;
using System.Text.Json.Serialization;
using Application.Responses;

namespace WEB.Models.Shared
{
    public class ListarPadraoViewModel
    {
        //[JsonPropertyName("ItensLista")]
        public List<itemLista> ItensLista { get; set; }

        //[JsonPropertyName("ItensLista")]
        public string TipoItem { get; set; }

        //[JsonPropertyName("PaginaAtual")]
        public int PaginaAtual { get; set; }

        //[JsonPropertyName("PaginaTotal")]
        public int PaginaTotal { get; set; }
        //[JsonPropertyName("TamanhoPagina")]
        public int TamanhoPagina { get; set; }
        //[JsonPropertyName("TotalItens")]
        public int TotalItens { get; set; }

        //[JsonPropertyName("Busca")]
        public string Busca { get; set; }

        public async Task<bool> ValidarCodigo(IConfiguration configuration)
        {
            using (var client = new HttpClient())
            {
                var baseUrl = configuration["BaseRequest"];
                var url = $"{baseUrl}/api/Aluno/GetAlunoByLikedName/{this.Busca}?pageNumber={this.PaginaAtual}&pageSize={this.TamanhoPagina}";

                try
                {
                    var response = await client.GetAsync(url);
                    if (!response.IsSuccessStatusCode) return false;

                    var responseBody = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var responseData = JsonSerializer.Deserialize<Response<ListarPadraoViewModel>>(responseBody, options);
                    if (responseData == null || !responseData.IsSuccess || responseData.Data == null) return false;

                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }

        public class itemLista
        {
            //[JsonPropertyName("Id")]
            public string Id { get; set; }

            //[JsonPropertyName("Text")]
            public string Text { get; set; }
        }
    }
}
